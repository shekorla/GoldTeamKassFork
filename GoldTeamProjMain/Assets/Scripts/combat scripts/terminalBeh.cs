using UnityEngine;
using UnityEngine.Events;

public class terminalBeh : MonoBehaviour
{
    public float lifetime;
    [Tooltip("happens before death")]
    public UnityEvent deathEv;
    private void OnEnable()
    {   //waits a few seconds then destroys itself, good for effects and such
        deathEv.Invoke();
        Destroy(this.gameObject,lifetime);
    }
}
