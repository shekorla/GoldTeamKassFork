using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class campBeh : MonoBehaviour
{
    public List<gruntEneBeh> babies;//why did i call it that?
    
    private int looping;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            looping = 0;
            foreach (var item in babies)
            {
                if (babies[looping].IsDestroyed()==false)//dont yell at corpses
                {
                    babies[looping].attack(); 
                    looping++;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            looping = 0;
            foreach (var item in babies)
            {
                if (babies[looping].IsDestroyed()==false)//dont yell at corpeses
                {
                    babies[looping].goHome();
                    looping++;
                }
            }
        }
    }
}
