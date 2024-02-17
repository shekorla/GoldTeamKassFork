using UnityEngine;
using UnityEngine.Events;

public class combatantBeh : MonoBehaviour
{
    //kassidy you still need to go back and fix the enemies code so they pause/atk
    
    //add this code to the being, an enemy the player etc. 
        //the weapon will handle if it hits something or not. the weapon will need a collider/weapon beh script
        //use the atk event to coordinate things such as animations
    
    public int maxHp=100, currentHp=100;
    public weaponSO myWeap;
    public HealthBar myHPbar;

    [Header("use this to give rewards for killing me")]   //need to create a pref that shows up, drops goodies and dies
    public UnityEvent deathEv;
    [Header("when the atk button hit")]
    public UnityEvent attackEv;
    [Header("use this for when I get hit")]
    public UnityEvent dmgEv;

    private combatantBeh hitYou;
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

    public void atkAction()//this can be called from a button or a script or whaterver
    {
        attackEv.Invoke();//turn the weapon hitbox on,,,maybe start an anim?
    }
    
    public void hitSomething(GameObject other)//the weapon calls this on contact
    {
        if (other.CompareTag("Player")||other.CompareTag("enemy"))//only player/enemies can be hit
        {
            hitYou=other.gameObject.GetComponent<combatantBeh>();
            hitYou.TakeDamage(myWeap.Dmg);//let the other know how much dmg to take
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
