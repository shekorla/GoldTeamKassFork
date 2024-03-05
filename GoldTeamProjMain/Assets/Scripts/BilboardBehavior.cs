using UnityEngine;

public class BilboardBehavior : MonoBehaviour
{
    public GameObject focusCam;

    private void Awake()
    {
        focusCam = GameObject.Find("MainCamera").GetComponent<Camera>();

    }

    public void LateUpdate()
    {
        transform.LookAt(focusCam.transform.position, -Vector3.up);
    }

    
}
