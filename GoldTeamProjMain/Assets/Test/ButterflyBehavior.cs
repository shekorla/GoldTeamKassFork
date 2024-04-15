using UnityEngine;

public class ButterflyBehavior : MonoBehaviour
{
    public float bobSpeed; 
    public float bobAmplitude; 
    public float speed = 1f;
    private Vector3 randomDestination;
    private bool isCirclingPlayer = false; 
    private float circleAngle = 0f; 
    public ButterflySpawner spawner;
    private float spawnAreaSize;
    private Transform cachedTransform;
    

    void Start()
    {
        cachedTransform = transform;
        spawner = cachedTransform.parent.GetComponent<ButterflySpawner>();
        spawnAreaSize = spawner.GetSpawnAreaSize();
        SetRandomDestination();

        bobSpeed = Random.Range(5f, 15f);
        bobAmplitude = Random.Range(0.05f, 0.15f);
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        cachedTransform.position = Vector3.MoveTowards(cachedTransform.position, randomDestination, step);

        cachedTransform.position = new Vector3(cachedTransform.position.x,
            cachedTransform.position.y + Mathf.Sin(Time.time * bobSpeed) * bobAmplitude, cachedTransform.position.z);

        Vector3 direction = (randomDestination - cachedTransform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            cachedTransform.rotation = Quaternion.Slerp(cachedTransform.rotation, toRotation, speed * Time.deltaTime);
        }

        if ((randomDestination - cachedTransform.position).sqrMagnitude < 0.001f)
        {
            SetRandomDestination();
        }
    }

    void SetRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * spawnAreaSize;
        randomDestination = cachedTransform.parent.position + randomDirection;
        if (cachedTransform.parent != null)
        {
            randomDestination = cachedTransform.parent.position + randomDirection;
        }
        else
        {
            Debug.LogError("ButterflyBehavior object does not have a parent.");
        }
        if (randomDestination.y < cachedTransform.parent.position.y)
        {
            randomDestination.y = cachedTransform.parent.position.y;
        }
    }
}