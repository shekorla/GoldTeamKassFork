using UnityEngine;

[CreateAssetMenu(fileName = "New Villager Settings", menuName = "NPC/Villager Settings")]
public class VillagerSettings : ScriptableObject
{
    public GameObject villagerPrefab;
    //public GameObject headPrefab;
    //public GameObject bodyPrefab;
    //public GameObject TailPrefab;
    public float walkAreaSize = 10f;
    public float minPauseDuration = 1f;
    public float maxPauseDuration = 3f;
    public float walkSpeed = 20; // Default walk speed for the NPC

    public AnimationClip idleAnimation; // Animation for idle state
    public AnimationClip walkAnimation; // Animation for walking state
}