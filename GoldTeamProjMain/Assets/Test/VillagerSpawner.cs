using UnityEngine;
using UnityEngine.AI;

public class VillagerSpawner : MonoBehaviour
{
    public VillagerSettings villagerSettings;

    void Start()
    {
        SpawnVillager();
    }

    public void SpawnVillager()
    {
        //GameObject body = Instantiate(villagerSettings.bodyPrefab, transform.position, Quaternion.identity);
        //GameObject head = Instantiate(villagerSettings.headPrefab, transform.position, Quaternion.identity);
        //GameObject tail = Instantiate(villagerSettings.TailPrefab, transform.position, Quaternion.identity);
        //head.transform.SetParent(body.transform);
        //tail.transform.SetParent(body.transform);
        GameObject villager = Instantiate(villagerSettings.villagerPrefab, transform.position, Quaternion.identity);

        VillagerBehavior villagerBehavior = villager.GetComponent<VillagerBehavior>();
        villagerBehavior.villagerSettings = villagerSettings;

        NavMeshAgent agent = villager.GetComponent<NavMeshAgent>();
        villagerBehavior.SetAgent(agent); // Use the SetAgent method
    }
}