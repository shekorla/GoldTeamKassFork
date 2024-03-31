using UnityEngine;

public class quickItemBeh : MonoBehaviour
{
    //the combatant code has a smaller verision of this code, idk if this code is still needed
    public GameObject prefab;
    
    public void quickItem(GameObject caller)
    {
        Instantiate(prefab, caller.transform.position,caller.transform.rotation);
    }

    public void newPref(GameObject nwe)
    {
        prefab = nwe;
    }
}
