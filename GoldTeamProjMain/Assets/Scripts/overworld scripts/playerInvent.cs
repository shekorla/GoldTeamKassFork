using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class playerInvent : ScriptableObject
{
   public int fuel, scrap, wood;
   public float timer=100;
   public Dictionary<string, bool> checkpoints=new Dictionary<string, bool>();//keep the unessesary new section, else it breaks things
   public List<string> villagers;
   
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
   
   //check if the region has been unlocked for fast travel
   public bool validTravelCheck(string region) 
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

   //turn on checkpoint of given region
   public void activateRegion(string thisOne)
   {
      checkpoints[thisOne] = true;
   }
   //when you get a drop add value to list
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
   //resets all values to default
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

   //reports the chosen value as a string, for display
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

   //when you save someone add them to the saved list
   public void savedVillager(string name)
   {
      if (!villagers.Contains(name))
      {
         villagers.Add(name);
      }
   }
   
   //check if we have already saved this villager
   public bool areTheyHere(string name)
   {
      if (villagers.Contains(name))
      {
         return true;
      }
      else
      {
         return false;
      }
   }
}
