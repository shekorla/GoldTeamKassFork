using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject valImg;
    public int maxVal;

    private RectTransform rectangle, hpRect;
    private void Awake()//awake happens before start
    {
        rectangle = GetComponent<RectTransform>();
        hpRect = valImg.GetComponent<RectTransform>();
    }

    public void maxChange(int newMax)  //upgrades the viz to match the stats
    {
        maxVal = newMax;
        Vector2 pos = rectangle.anchoredPosition;
        Vector2 size = rectangle.sizeDelta;
        pos.x=((maxVal/2)+10);
        size.x = maxVal;
        rectangle.anchoredPosition = pos;
        rectangle.sizeDelta = size;
        updateVal(maxVal);
    }

    public void updateVal(int currentVal)//updates the healthy image to shrink
    {
        Vector2 rect = hpRect.sizeDelta;
        rect.x=((maxVal - currentVal)*(-1));//shrink by the perportion of hp lost
        hpRect.sizeDelta = rect;
    }
}
