
using UnityEngine;

public class KnockBackBehavior : MonoBehaviour
{
    private Rigidbody rb;
    public IntData TargetSpeed;
    private int i;

    public FloatListData Launchspeeds;
    // nothing too fancy here, shoves an object backward. distance is based on a list of floatdata values, with the target speed intdata as the value selector. call updatevalue on targetspeed to change the current launch speed.
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    
    public void KnockBack()
    {
        i = TargetSpeed.value;
        print("Knockback activated Value number"+ Launchspeeds.floatList[i]);
        rb.AddForce(transform.forward * Launchspeeds.floatList[i]);
    }
}
