using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject valImg;

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

    public void updateVal(int currentVal)//updates the healthy image
    {
        size = hpRect.sizeDelta;
        size.x=(currentVal);
        hpRect.sizeDelta = size;
    }
}
