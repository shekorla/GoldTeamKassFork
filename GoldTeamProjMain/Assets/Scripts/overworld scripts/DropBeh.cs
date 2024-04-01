using System;
using UnityEngine;

public class DropBeh : MonoBehaviour
{
    public int value,despawnTime;
    [Tooltip("lowercase or it wont work")]
    public string type;
    public playerInvent bag;
    public GameObject parent;


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))//dont execute for everything
        {
            //id like to add code here later to allow it to float towards the player
            bag.addThings(value,type);
            Destroy(parent);
        }
    }

    private void Start()
    {
        Destroy(parent,despawnTime);
    }
}
