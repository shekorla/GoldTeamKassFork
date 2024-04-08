using System;
using UnityEngine;
using UnityEngine.UI;
using Environment = System.Environment;

public class savedListBeh : MonoBehaviour
{
    public Text textbox;
    public playerInvent invent;

    private string temp;
    //this just prints the list of saved villagers
    void Start()
    {
        foreach (var word in invent.villagers)
        {
            temp=String.Join(Environment.NewLine, word);//adds the next item on a new line
        }
        textbox.text = temp;
    }

}
