using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConfigureRoom : MonoBehaviour
{
    public GameObject nWall, sWall, eWall, wWall, floor,plr;
    public UnityEvent swapEv;
    public RoomData readRoomData,WriteRoomData;

    private int loopingNum;
    public List<GameObject> currentMisc;

    public void Start()//this gets called everytime the scene loads
    {
        swap(WriteRoomData);
    }

    public void swap(RoomData newby)
    {
        readRoomData = newby;
        swapEv.Invoke();//use this to get the loading screen
        setup();
    }
    public void SetWall(GameObject prefabb,GameObject Parentt)//creates an instance of the wall prefab as a child
    {//its easier to swap game objs than to change tex so the floor gets changed using this method too
        if (Parentt.transform.childCount!=0)
        {
            Destroy(Parentt.transform.GetChild(0).gameObject);//clears out old wall
        }
        Instantiate(prefabb,Parentt.transform);//new wall as child
    }
    
    public void setup()//we can create room datas to quickly build new areas
    {
        plr.transform.position = readRoomData.spawnPoint;
        foreach (var thingy in currentMisc)
        {
            Destroy(thingy.gameObject);
        }
        currentMisc.Clear();//idk if this is needed but it makes me feel better
        SetWall(readRoomData.nWall,nWall);
        SetWall(readRoomData.eWall,eWall);
        SetWall(readRoomData.sWall,sWall);
        SetWall(readRoomData.wWall,wWall);
        SetWall(readRoomData.floor,floor);
        loopingNum = 0;
        foreach (var item in readRoomData.contentObjs)
        {
            //make sure that the objs in the first list match the transforms in the second list.
            currentMisc.Add(Instantiate(readRoomData.contentObjs[loopingNum],readRoomData.locations[loopingNum],new Quaternion(0,0,0,0)));
            loopingNum++;//kassidy stop being an idiot and trying to take this out, it wont work
        }
    }

    public void leaveRoom() //take a picture of everything currently left in room
    {
        int looping=0;
        foreach (var item in currentMisc)
        {
            WriteRoomData.contentObjs[looping]=item;
            WriteRoomData.locations[looping] = item.transform.position;
            looping++;
        }
        WriteRoomData.spawnPoint = plr.transform.position;
    }

    public void removeMe(GameObject dead)//when you break a thing remove it from room memory
    {
        foreach (var item in currentMisc)
        {
            if (item==dead)
            {
                currentMisc.Remove(item);
                Destroy(dead);
            }
        }
    }

    
}
