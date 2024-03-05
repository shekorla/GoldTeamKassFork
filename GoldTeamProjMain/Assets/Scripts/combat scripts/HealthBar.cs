using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject valImg;
    public int maxVal;

    private RectTransform rectangle, hpRect;
    private Vector2 pos, size;
    private void Awake()//awake happens before start
    {
        rectangle = GetComponent<RectTransform>();
        hpRect = valImg.GetComponent<RectTransform>();
    }

    public void maxChange(int newMax)  //upgrades the viz to match the stats
    {
        maxVal = newMax;
        pos = rectangle.anchoredPosition;
        size = rectangle.sizeDelta;
        pos.x=((maxVal/2)+10);
        size.x = maxVal;
        rectangle.anchoredPosition = pos;
        rectangle.sizeDelta = size;
        hpRect.sizeDelta = size;
        updateVal(maxVal);
    }

    public void updateVal(int currentVal)//updates the healthy image to shrink
    {
        pos.y = 0;
        pos.x = (currentVal / 2);
        size = hpRect.sizeDelta;
        size.x=(currentVal);//shrink by the perportion of hp lost
        hpRect.sizeDelta = size;
        hpRect.anchoredPosition = pos;
    }
}
