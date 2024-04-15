using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class VillagerBehavior : MonoBehaviour
{
    public VillagerSettings villagerSettings;
    public Transform playerTransform;
    public TMP_Text dialogueText;
    private NavMeshAgent agent;
    private Vector3 randomDestination;
    private bool isPaused;
    private float pauseTimer;
    private Rigidbody rb;
    public Dialogue dialogue;
    private bool hasSpawned = false;
    private Animator animator;
    private float destinationTimer;
    private float destinationTimeout = 10f;
    public UnityEvent walkingAnimation, stopWalkingAnimation;
    public Transform headJoint;
    public float lookAtPlayerDistance = 5f;
    private Quaternion initialHeadRotation;
    private Transform myTransform; // Cached transform

    void Start()
    {
        myTransform = transform; // Cache transform
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        agent.speed = villagerSettings.walkSpeed;
        SetRandomDestination();
        initialHeadRotation = myTransform.rotation;
    }

    void LateUpdate()
    {
        if (isPaused)
        {
            pauseTimer -= Time.deltaTime;
            if (pauseTimer <= 0f)
            {
                isPaused = false;
                SetRandomDestination();
            }
            stopWalkingAnimation.Invoke();
        }
        else
        {
            destinationTimer += Time.deltaTime;
            if (destinationTimer >= destinationTimeout)
            {
                SetRandomDestination();
                destinationTimer = 0f;
            }
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                isPaused = true;
                pauseTimer = Random.Range(villagerSettings.minPauseDuration, villagerSettings.maxPauseDuration);
            }
            else
            {
                walkingAnimation.Invoke();
            }
        }

        float distanceToPlayer = (playerTransform.position - myTransform.position).sqrMagnitude; // Use sqrMagnitude for distance check
        if (distanceToPlayer <= lookAtPlayerDistance * lookAtPlayerDistance)
        {
            Quaternion lookAtPlayerRotation = Quaternion.LookRotation(playerTransform.position - headJoint.position);
            Quaternion lookForwardRotation = Quaternion.LookRotation(myTransform.forward);
            float lerpFactor = Mathf.InverseLerp(lookAtPlayerDistance, 0, Mathf.Sqrt(distanceToPlayer));
            Quaternion newRotation = Quaternion.Lerp(lookAtPlayerRotation, lookForwardRotation, lerpFactor);
            newRotation = Quaternion.RotateTowards(headJoint.rotation, newRotation, 15f);
            Vector3 eulerRotation = newRotation.eulerAngles;
            eulerRotation.z = 0;
            headJoint.rotation = Quaternion.Slerp(headJoint.rotation, Quaternion.Euler(eulerRotation), Time.deltaTime * 15f);
        }
        else
        {
            Vector3 lookAtDestination = new Vector3(agent.destination.x, headJoint.position.y, agent.destination.z);
            Quaternion lookAtDestinationRotation = Quaternion.LookRotation(lookAtDestination - headJoint.position);
            Quaternion newRotation = Quaternion.Lerp(headJoint.rotation, lookAtDestinationRotation, Time.deltaTime * 20f);
            newRotation *= Quaternion.Inverse(myTransform.rotation);
            Vector3 eulerRotation = newRotation.eulerAngles;
            eulerRotation.y = Mathf.Clamp(eulerRotation.y, -5f, 5f);
            eulerRotation.z = 0;
            newRotation = Quaternion.Euler(eulerRotation);
            headJoint.localRotation = Quaternion.Slerp(headJoint.localRotation, newRotation, Time.deltaTime * 30f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Use CompareTag for tag comparison
        {
            print("Coll");
            DisplayDialogue();
        }
    }

    void OnTriggerExit(Collider other)
    {
        HideDialogue();
    }

    void DisplayDialogue()
    {
        if (dialogue != null && dialogueText != null)
        {
            dialogueText.text = string.Join("\n", dialogue.dialogueLines);
            dialogueText.gameObject.SetActive(true);
        }
    }

    void HideDialogue()
    {
        if (dialogueText != null)
        {
            dialogueText.gameObject.SetActive(false);
        }
    }

    void SetRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * villagerSettings.walkAreaSize;
        randomDirection += myTransform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, villagerSettings.walkAreaSize, 1);
        randomDestination = hit.position;
        agent.SetDestination(randomDestination);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(myTransform.position, new Vector3(villagerSettings.walkAreaSize * 2f, 0.1f, villagerSettings.walkAreaSize * 2f));
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(myTransform.position, randomDestination);
        Gizmos.DrawWireCube(randomDestination, new Vector3(3,3,3));
    }

    public void SetAgent(NavMeshAgent agent)
    {
        this.agent = agent;
    }
}