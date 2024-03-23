using UnityEngine;
using UnityEngine.Events;

public class combatantBeh : MonoBehaviour
{
    //add this code to the being, an enemy the player etc. on the obj that has the hurt box, it should be a trigger
        //the weapon will handle if it hits something or not. the weapon will need a collider/weapon beh script
        //this code essentially handels hp/death/loot
    
    public int maxHp=100, currentHp=100;
    public HealthBar myHPbar;

    [Header("use this to give rewards for killing me")]   //need to create a pref that shows up, drops goodies and dies
    public UnityEvent deathEv;
    [Header("use this for when I get hit")]
    public UnityEvent dmgEv;

    
    private void Start()
    {
        currentHp = maxHp;
        if (myHPbar==null)//yes i know im forgetful, stop giving me error codes!
        {
            myHPbar = GetComponentInChildren<HealthBar>();
        }
        myHPbar.maxChange(maxHp);
    }

    public void TakeDamage(int val)
    {
        // can add complex code here to change for atk dmg vs def etc.
        currentHp -= val;
        myHPbar.updateVal(currentHp);
        dmgEv.Invoke();
        if (currentHp <= 0)
        {
            deathEv.Invoke();
            Destroy(this.gameObject);
        }
    }
    
    public void quickItem(GameObject prefab)
    {
        Instantiate(prefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }

    public void UpgradeHp(int newval)
    {
        maxHp = newval;
        currentHp = maxHp;
        myHPbar.maxChange(maxHp);
    }
}
