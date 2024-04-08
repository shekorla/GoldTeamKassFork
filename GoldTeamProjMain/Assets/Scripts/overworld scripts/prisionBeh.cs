using System;
using UnityEngine;

public class prisionBeh : MonoBehaviour
{
    public GameObject villager;

    private void Start()
    {
        throw new NotImplementedException();
    }

    public void saved()
    {
        //add stuff here later to make them animate before die
        GameObject.Find("base room").BroadcastMessage("removeMe",this.gameObject);
        Destroy(this.gameObject);
    }
}
