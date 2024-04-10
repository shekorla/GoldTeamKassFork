using UnityEngine;
using UnityEngine.Events;

public class GameActionHandler : MonoBehaviour
{
    public GameAction gameActionObj;
    public UnityEvent onRaiseEvent;
    private void Awake()
    {
        gameActionObj.raise += Raise;
    }

    private void Raise()
    {
        //print(gameActionObj.name + " raised on " + gameObject.name);
        onRaiseEvent.Invoke();
    }
}
