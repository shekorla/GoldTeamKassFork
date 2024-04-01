
using UnityEngine;

public class KnockBackBehavior : MonoBehaviour
{
    private Rigidbody rb;
    // nothing too fancy here, shoves an object backward (currently at a hardcoded rate, planning to fix that soon)
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    public void KnockBack()
    {
        print("Knockback activated");
        rb.AddForce(transform.forward * -300);
    }
}
