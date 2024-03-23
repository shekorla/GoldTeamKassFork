using UnityEngine;

public class weaponBeh : MonoBehaviour
{
    //this code should be added to the weapon used by a being that has the combantant beh script added
    
    public weaponSO myWeap;
    
    private combatantBeh target,parent;
    private Collider myTrigger;
    private combatantBeh hitYou;

    private void Awake()
    {
        myTrigger = GetComponent<Collider>();
    }

    public void turnOn()
    {
        myTrigger.enabled = true;
    }

    public void turnOff()
    {
        myTrigger.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")||other.CompareTag("enemy"))//only player/enemies can be hit
        {
            parent = GetComponentInParent<combatantBeh>();   
            target=other.GetComponentInParent<combatantBeh>();
            
            if (parent!=target)//stop hitting yourself
            {
                hitYou=other.gameObject.GetComponent<combatantBeh>(); 
                hitYou.TakeDamage(myWeap.Dmg);//let the other know how much dmg to take;
            }

            
        }
    }
}
