using UnityEngine;

public class weaponBeh : MonoBehaviour
{
    
    private combatantBeh target,parent;
    private Collider myTrigger;

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
            Debug.Log(parent+"parent       target"+target);
            if (parent!=target)//stop hitting yourself
            {
                
                target.hitSomething(other.gameObject);
            }
        }
        
    }
}
