
using UnityEngine;
using UnityEngine.Events;

public class LogicGateBehavior : MonoBehaviour
{

    public UnityEvent trueEvent, falseEvent;
    public int compareToTarget;
    public IntData comparing;

    public void IsComparingMoreThan()
    {
        if (comparing.value >= compareToTarget)
        {
            trueEvent.Invoke();
        }
        else
        {
            falseEvent.Invoke();
        }
    }
    
    public void IsComparinglessThan()
    {
        if (comparing.value <= compareToTarget)
        {
            trueEvent.Invoke();
        }
        else
        {
            falseEvent.Invoke();
        }
    }
}



