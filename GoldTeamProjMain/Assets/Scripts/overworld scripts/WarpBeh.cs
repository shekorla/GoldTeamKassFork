using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class WarpBeh : MonoBehaviour
{
    public UnityEvent mapEv, activeEv;
    public bool active;
    public string myReigon;
    public playerInvent plrinvt;
    public uiMenuBeh menu;

    public void Start()
    {
        menu = GameObject.Find("JoyCanvas").GetComponent<uiMenuBeh>();
        if (plrinvt.validTravelCheck(myReigon))//if this point is unlocked
        {
            active = true;//make sure that this code works
            activeEv.Invoke();//connect the animations
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (active==false)
        {
            if (other.gameObject.CompareTag("Weapon"))
            {
                active = true;
                activeEv.Invoke(); //turn on /power up
            }
        }
        else
        {
            if (other.gameObject.CompareTag("Player"))
            {
                menu.BroadcastMessage("changeState","teleport"); //this opens the ui for traveling via map
            }
        }
    }
}
