using UnityEngine;

public class uiMenuBeh : MonoBehaviour
{
   public GameObject[] panels;//this assumes that the order is play, load, pause;
   public float loadTime = 2;
   
   public void changeState(string state)
   {
      //this will change the ui to match what is happening
      //for example when the game is paused only the pause
      //     screen will be active and time will be paused
      switch (state)
      {
         case "play":
            swap3(0);
            Time.timeScale = 1;
            break;
         case "load":
            Time.timeScale = 1;//idk if this is actually needed
            swap3(1);
            new WaitForSecondsRealtime(loadTime);//keeps the player from doing anything for 2 seconds
            swap3(0);
            break;
         case "pause":
            swap3(2);
            Time.timeScale = 0;
            break;
      }
   }

   private void swap3(int which)//this assumes that the order is play, load, pause
   {
      foreach (var item in panels)
      {
         item.SetActive(false);
      }
      panels[which].SetActive(true);
   }
   
   
}
