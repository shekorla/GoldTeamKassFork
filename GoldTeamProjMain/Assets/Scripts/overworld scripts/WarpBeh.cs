using UnityEngine;
using UnityEngine.Events;

public class WarpBeh : MonoBehaviour
{
    public UnityEvent mapEv, activeEv;
    public bool active;
    public string myReigon;
    public playerInvent plrinvt;

    public void Start()
    {
        if (plrinvt.validTravelCheck(myReigon))//if this point is unlocked
        {
            active = true;//make sure that this code works
            activeEv.Invoke();//connect the animations
        }
    }
    private void OnCollisionEnter(Collision other)
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
                mapEv.Invoke(); //this opens the ui for traveling via map
            }
        }
    }
}
