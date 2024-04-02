
using UnityEngine;
using UnityEngine.Events;

public class OnAwakeEventBehavior : MonoBehaviour
{

    public UnityEvent startEvent;
    void Awake()
    {
        startEvent.Invoke();
    }

}
