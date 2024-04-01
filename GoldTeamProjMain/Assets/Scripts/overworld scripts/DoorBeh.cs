using UnityEngine;

public class DoorBeh : MonoBehaviour
{
    public RoomData WhereTo;
    public Vector3 plrSpot;
    
    
    private GameObject baseR;
    public void OnEnable()//when its created it will find the base room
    {
        baseR=GameObject.Find("base room");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))// when player enters door, setup where to go and then go there
        {
            WhereTo.spawnPoint = plrSpot;
            baseR.BroadcastMessage("swap", WhereTo);//this is jsut calling the function
        }
    }
}
