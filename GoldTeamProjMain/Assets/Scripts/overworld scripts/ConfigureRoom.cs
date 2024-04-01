using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConfigureRoom : MonoBehaviour
{
    public GameObject nWall, sWall, eWall, wWall, floor,plr;
    public UnityEvent swapEv;
    public RoomData newRoom;

    private int loopingNum;
    public List<GameObject> currentMisc;

    public void Start()
    {
        newRoom.spawnPoint = new Vector3(0, 0, -230);// start just outside of city
        swapEv.Invoke();
        setup();
    }

    public void swap(RoomData newby)
    {
        newRoom = newby;
        swapEv.Invoke();//use this to get the loading screen
        setup();
    }
    
    public void setup()//we can create room datas to quickly build new areas
    {
        plr.transform.position = newRoom.spawnPoint;
        foreach (var thingy in currentMisc)
        {
            Destroy(thingy.gameObject);
        }
        currentMisc.Clear();//idk if this is needed but it makes me feel better
        SetWall(newRoom.nWall,nWall);
        SetWall(newRoom.eWall,eWall);
        SetWall(newRoom.sWall,sWall);
        SetWall(newRoom.wWall,wWall);
        SetWall(newRoom.floor,floor);
        loopingNum = 0;
        foreach (var item in newRoom.contentObjs)
        {
            //make sure that the objs in the first list match the transforms in the second list.
            currentMisc.Add(Instantiate(newRoom.contentObjs[loopingNum],newRoom.locations[loopingNum],new Quaternion(0,0,0,0)));
            loopingNum++;//kassidy stop being an idiot and trying to take this out, it wont work
        }
    }


    private void SetWall(GameObject prefabb,GameObject Parentt)//creates an instance of the wall prefab as a child
    {//its easier to swap game objs than to change tex so the floor gets changed using this method too
        if (Parentt.transform.childCount!=0)
        {
            Destroy(Parentt.transform.GetChild(0).gameObject);//clears out old wall
        }
        Instantiate(prefabb,Parentt.transform);//new wall as child
    }
}
