using UnityEngine;

[CreateAssetMenu(fileName = "New Villager Settings", menuName = "NPC/Villager Settings")]
public class VillagerSettings : ScriptableObject
{
    public GameObject villagerPrefab;
    public float walkAreaSize = 10f;
    public float minPauseDuration = 1f;
    public float maxPauseDuration = 3f;
    public float walkSpeed = 3.5f; // Default walk speed for the NPC
    public float jumpForce = 2f; // Amount of force to apply when jumping on collision
}