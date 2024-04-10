using UnityEngine;

public class prisionBeh : MonoBehaviour
{
    public void saved()
    {
        //add stuff here later to make them animate before die
        GameObject.Find("base room").BroadcastMessage("removeMe",this.gameObject);
    }
}
