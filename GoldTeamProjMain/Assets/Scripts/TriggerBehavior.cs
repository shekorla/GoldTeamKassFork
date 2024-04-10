using UnityEngine;
using UnityEngine.Events;

public class TriggerBehavior : MonoBehaviour
{
    public UnityEvent triggerStartEvent, triggerEndEvent,playerEvent, weaponEvent, parryEvent;

    private void OnTriggerEnter(Collider other)
    {
        triggerStartEvent.Invoke();
        //i hope you dont mind me adding these it just checks what it is being hit by
        //print("collision: "+other.tag );
        if (other.CompareTag("Player"))
        {
            playerEvent.Invoke();
        }

        if (other.CompareTag("Weapon"))
        {
            
            weaponEvent.Invoke();
        }
        
        if (other.CompareTag("Parry"))
        {
            parryEvent.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        triggerEndEvent.Invoke();
    }
}
