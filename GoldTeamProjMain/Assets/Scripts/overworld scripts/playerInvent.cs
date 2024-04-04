using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class playerInvent : ScriptableObject
{
   public int fuel, scrap, wood, timer;
   public Dictionary<string, bool> checkpoints=new Dictionary<string, bool>();//keep the unessesary new section, else it breaks things

   public void Awake()
   {
      try //this stop doubles
      {
         checkpoints.Add("town",true);
         checkpoints.Add("plains",true);
         checkpoints.Add("forest",false);
         checkpoints.Add("junk",false);
         checkpoints.Add("cave",false);
      }
      catch (Exception e)//will print things if its broken
      {
         Console.WriteLine("player inventory dictionary broken"+ e);
         throw;
      }
   }

   public bool validTravelCheck(string region) //if youve already unlocked this spot then you can use it
   {
      foreach (var spot in checkpoints)
      {
         if (spot.Key==region)
         {
            return spot.Value;
         }
      }
      return false;
   }

   public void activateRegion(string thisOne)
   {
      checkpoints[thisOne] = true;
   }
   public void addThings(string type, int amt)
   {
         switch (type)
         {
            case "fuel":
               fuel += amt;
               break;
            case "scrap":
               scrap += amt;
               break;
            case "wood":
               wood += amt;
               break;
            case "timer":
               timer += amt;
               break;
         }
      }
      public void FullReset()
      {
         fuel = 0;
         scrap = 0; 
         wood = 0; 
         timer = 100;
         checkpoints["town"] = true;
         checkpoints["plains"] = false;
         checkpoints["forest"] = false;
         checkpoints["junk"] = false;
         checkpoints["cave"] = false;
         
      }

   public string reportVal(string what)
   {
      string value = null;//local variable so we can respond with something
      switch (what)
      {
         case "fuel":
            value = fuel.ToString();
            break;
         case "scrap":
            value = scrap.ToString();
            break;
         case "wood":
            value = wood.ToString();
            break;
         case "timer":
            value = timer.ToString();
            break;
      }
      return value;
   }
   
}
