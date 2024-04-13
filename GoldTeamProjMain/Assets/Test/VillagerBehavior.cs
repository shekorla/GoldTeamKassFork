using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class VillagerBehavior : MonoBehaviour
{
    public VillagerSettings villagerSettings;
    public Transform playerTransform; // Reference to the player's transform
    public TMP_Text dialogueText; // Reference to the UI text element for dialogue

    private NavMeshAgent agent;
    private Vector3 randomDestination;
    private bool isPaused;
    private float pauseTimer;
    private Rigidbody rb;
    public Dialogue dialogue; // Reference to the dialogue scriptable object
    private bool hasSpawned = false;
    private Animator animator; // Reference to the Animator component
    private float destinationTimer; // Timer for reaching the destination
    private float destinationTimeout = 10f; // Time allowed to reach the destination
    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
        animator = GetComponent<Animator>();

        // Set the walk speed of the NavMeshAgent
        agent.speed = villagerSettings.walkSpeed;

        
        SetRandomDestination();
    }

    void Update()
    {
        // ... existing code ...

        if (isPaused)
        {
            // If currently paused, decrement the pause timer
            pauseTimer -= Time.deltaTime;

            // If the pause timer has reached zero, resume walking
            if (pauseTimer <= 0f)
            {
                isPaused = false;
                SetRandomDestination();
            }

            // Set the IsWalking parameter to false
            animator.Play("Skull_Walk_Anim");

            print("Stopping");
        }
        else
        {
            // If chasePlayer is disabled or playerTransform is not set, wander randomly
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                isPaused = true;
                pauseTimer = Random.Range(villagerSettings.minPauseDuration, villagerSettings.maxPauseDuration);
            }
            else
            {
                // Set the IsWalking parameter to true
                animator.Play("Skull_Stun_Anim");

            print("Walking");
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player bumped into the NPC, display dialogue
            print("Coll");
            DisplayDialogue();
        }
    }
    void OnTriggerExit(Collider other)
    {
       
            // Player moved away from the NPC, hide dialogue
        HideDialogue();
        
    }
    void DisplayDialogue()
    {
        if (dialogue != null && dialogueText != null)
        {
            // Set dialogue text to the lines retrieved from the dialogue scriptable object
            dialogueText.text = string.Join("\n", dialogue.dialogueLines);

            // Show the dialogue UI
            dialogueText.gameObject.SetActive(true);
        }
    }
    void HideDialogue()
    {
        if (dialogueText != null)
        {
            // Hide the dialogue UI
            dialogueText.gameObject.SetActive(false);
        }
    }
    void SetRandomDestination()
    {
        // Generate a random point within the walk area
        Vector3 randomDirection = Random.insideUnitSphere * villagerSettings.walkAreaSize;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, villagerSettings.walkAreaSize, 1);
        randomDestination = hit.position;

        // Set the new random destination for the NPC
        agent.SetDestination(randomDestination);
    }

    // Draw a wireframe representation of the walk area in the scene view
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(villagerSettings.walkAreaSize * 2f, 0.1f, villagerSettings.walkAreaSize * 2f));
    }
    public void SetAgent(NavMeshAgent agent)
    {
        this.agent = agent;
    }
    
}
