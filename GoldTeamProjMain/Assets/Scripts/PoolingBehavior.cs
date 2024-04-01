using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
// this code takes a list of prefabs, and instanciates the full list across the available spawnpoints. stops spawning at the end of the list.
//IIRC this code shouldn't need a coroutine to function. in the future I really need to rework the enemybehavior to work more like this.
public class PoolingBehavior : MonoBehaviour
{

    public List<Transform> poolList;
    //hardcoded to wait 2 seconds between spawns, but could easily be changed to a floatdata for easier manipulation
    public float seconds = 2f;
    private WaitForSeconds wfsObj;
    private int i;
    public bool canRun = true;
    public Vector3DataList Spawns;

    IEnumerator Start()
    {

        wfsObj = new WaitForSeconds(seconds);
        while (canRun)
        {
            Instantiate(poolList[i]);
            yield return wfsObj;
            poolList[i].position = Spawns.vector3List[i].value;
            //print("Spawning" + i);
            i++;
            if (i > poolList.Count - 1)
            {
                i = 0;
                canRun = false;

            }


        }



    }
}
