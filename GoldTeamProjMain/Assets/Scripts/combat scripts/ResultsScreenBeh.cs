using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultsScreenBeh : MonoBehaviour
{
    public playerInvent plrInvet;
    public GameObject joycanvas, textBoss, panel;
    [Header("ignore these")]
    public bool leave;
    public Text textbox;

    public int lootlist;//currently enemies can only add to explore timer, change loot later
    
    
    private void Start()
    {
        panel.SetActive(false);
        lootlist = 0;
        textbox = textBoss.GetComponentInChildren<Text>();
        leave = false;
    }
    
    public void addTime(int amt)//when an enemy dies call this
    {
        lootlist+=amt;
    }
    
    public void CarrotTime()//open up the results screen and wait to exit
    {
        joycanvas.SetActive(false);//turn of joy contoller
        Time.timeScale = 0;     //pause time
        panel.SetActive(true);//turn on results screen
        //tell the inventory what we got
        plrInvet.addThings("timer",lootlist);
        
        //display rewards on screen
        textbox.text = "Time Added: "+lootlist;
        leave = true;
    }

    public void vacate()//if the results screen is open, then we can go
    {
        if (leave==true)
        {
            //change here if need to load room weird
            SceneManager.LoadScene("overworld");
        }
    }
}
