using UnityEngine;

public class BilboardBehavior : MonoBehaviour
{
    //this code tells an object to face at the target camera, creating a "billboarding" effect when used on 2D objects. designed to be called by a coroutine.
    public Camera focusCam;

    private void Start()
    {
        if (focusCam==null)
        {
            focusCam = GameObject.Find("MainCamera").GetComponent<Camera>();
        }

    }

    public void Billboard()
    {
        
        transform.LookAt(focusCam.transform.position, -Vector3.up);
        
    }

    
}
