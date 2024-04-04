using UnityEngine;

public class uiMapBeh : MonoBehaviour
{
    public GameObject[] spots;
    public playerInvent plrMp;

    private void OnEnable()
    {
        foreach (var item in spots)
        {
            if (plrMp.validTravelCheck(item.ToString()))//if the spot is unlocked
            {
                item.SetActive(true);
            }
            else
            {
                item.SetActive(false);
            }
        }
    }
}
