using System.Collections;
using UnityEngine;

public class loadScrBeh : MonoBehaviour
{
    public float timer=2;

    private float tic;
    private void OnEnable()
    {
        tic = timer;
        if(isActiveAndEnabled)
        {
            StartCoroutine(deactive());
        }
    }

    private IEnumerator deactive()
    {
        while (tic>0)
        {
            tic -=1;
            print(tic);
            yield return new WaitForSeconds(1);
        }
        print("asfjkld");
        this.gameObject.SetActive(false);
    }
}
