using System;
using UnityEngine;

public class uiMenuBeh : MonoBehaviour
{
   //this code only works if all of the ui elements are grouped under parent objects.
   [Header("play,load,pause,teleport")]
   public GameObject[] panels;//this assumes that the order is play, load, pause, teleport;

   private void Start()
   {
      changeState("play");
   }

   public void changeState(string state)
   {
      //this will change the ui to match what is happening for example when the game is paused only the pause
      //     screen will be active and time will be paused
      switch (state)
      {
         case "play":
            swap(0);
            Time.timeScale = 1;
            break;
         case "load":
            Time.timeScale = 1;//idk if this is actually needed
            swap(1);
            break;
         case "pause":
            swap(2);
            Time.timeScale = 0;
            break;
         case "teleport":
            swap(3);
            Time.timeScale = 0;
            break;
      }
   }

   private void swap(int which)//this assumes that the order is play, load, pause, telport
   {
      foreach (var item in panels)
      {
         item.SetActive(false);
      }
      panels[which].SetActive(true);
   }
   
   
}
