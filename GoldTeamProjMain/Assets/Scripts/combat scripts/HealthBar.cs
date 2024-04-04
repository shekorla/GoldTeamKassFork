using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject valImg;
    public IntData maxHp;
    
    private RectTransform rectangle, hpRect;//rectangle is the full healthbar, hp rect is the green portion
    private Vector2 size;
    private void Awake()//awake happens before start
    {
        rectangle = GetComponent<RectTransform>();
        hpRect = valImg.GetComponent<RectTransform>();
    }

    public void maxChange(int newMax)  //upgrades the viz to match the stats
    {
        size = rectangle.sizeDelta;//get current width & height
        size.x = newMax;//set width to new max health
        rectangle.sizeDelta = size;//update the actual canvas element
        hpRect.sizeDelta = size;//update the green bit
        updateVal(newMax);
    }
    public void maxChangeToIntData(IntData newMax)  //upgrades the viz to match a given Int Data Value. Hope these additions were OK, this way player's max & current can be stored in Scriptable Objects.
    {
        size = rectangle.sizeDelta;//get current width & height
        size.x = newMax.value;//set width to new max health
        rectangle.sizeDelta = size;//update the actual canvas element
        hpRect.sizeDelta = size;//update the green bit
        updateVal(newMax.value);
    }

    public void updateVal(int currentVal)//updates the healthy image
    {
        valImg.GetComponent<Image>().fillAmount=(currentVal/maxHp.value);
        //this is old code, delete later
        // size = hpRect.sizeDelta;
        // size.x=(currentVal);
        // hpRect.sizeDelta = size;
    }
    public void updateValueToIntData(IntData obj)//variant that updates the healthy image to a given Intdata's value
    {
        valImg.GetComponent<Image>().fillAmount=(obj.value/maxHp.value);
        //size = hpRect.sizeDelta;
        //size.x=(obj.value);
        //hpRect.sizeDelta = size;
    }  
    
    
}
