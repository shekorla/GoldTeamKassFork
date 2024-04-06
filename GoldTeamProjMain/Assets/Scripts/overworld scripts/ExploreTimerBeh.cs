using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HealthBar))]
public class ExploreTimerBeh : MonoBehaviour
{
    public playerInvent invent;
    public int StartVal=100;
    public UnityEvent timesUp;
    public IntData plrHealth;
    
    private HealthBar display;
    private WaitForSeconds delay;
    void Start()
    {
        invent.timer = StartVal;
        delay = new WaitForSeconds(1);
        display = GetComponent<HealthBar>();
        StartCoroutine(Countdown());
    }

    public void upgradeTimer(int newval)
    {
        invent.timer = newval;
        display.maxChange(newval);
    }


    IEnumerator Countdown()
    {
        while (invent.timer>0)
        {
            invent.timer -= 1;
            display.updateVal(invent.timer);
            yield return delay;
        }
        while (plrHealth.value>0)
        {
            timesUp.Invoke(); 
        }
        
    }
}
