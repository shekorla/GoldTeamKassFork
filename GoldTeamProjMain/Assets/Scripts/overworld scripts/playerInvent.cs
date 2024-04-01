using UnityEngine;
[CreateAssetMenu]

public class playerInvent : ScriptableObject
{
   public int fuel, scrap, wood,timer;

   //simplify the code for changing vals, can i have one funtion handel all of them?
      //maybe a funtion that accepts a string and then read it as (name,value)

      public void addThings(int amt, string type)
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
      public void reset(int amt, string type)
      {
         switch (type)
         {
            case "fuel":
               fuel = amt;
               break;
            case "scrap":
               scrap = amt;
               break;
            case "wood":
               wood = amt;
               break;
            case "timer":
               timer = amt;
               break;
         }
      }

   public string reportRes(string what)
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
