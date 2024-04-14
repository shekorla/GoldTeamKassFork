using UnityEngine;

public class ButterflySpawner : MonoBehaviour
{
    public GameObject butterflyPrefab;
    public int butterflyCount = 10;
    public float spawnAreaSize = 10f;
    private Transform cachedTransform;

    void Start()
    {
        cachedTransform = transform;
        for (int i = 0; i < butterflyCount; i++)
        {
            SpawnButterfly();
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a wireframe sphere to represent the fly area
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(cachedTransform.position, spawnAreaSize);
    }

    public float GetSpawnAreaSize()
    {
        return spawnAreaSize;
    }

    void SpawnButterfly()
    {
        Vector3 spawnPosition = Random.insideUnitSphere * spawnAreaSize;
        spawnPosition += cachedTransform.position;
        GameObject butterfly = Instantiate(butterflyPrefab, spawnPosition, Quaternion.identity);
        butterfly.transform.parent = cachedTransform; // Set the spawner object as the parent
    }
}