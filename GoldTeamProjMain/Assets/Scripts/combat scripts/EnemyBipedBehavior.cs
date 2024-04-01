using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;


public class EnemyBipedBehavior : EnemyBase
//this code is designed to have it's "Think" function called by a coroutine at a set "tic" rate, allowing enemies to react pretty quickly without doing so 60+ times a second. most everything else is handled automatically, but it does need an animatable model with an animator, for attacking to function.
{
    [Header("Entity Management")]
    //establishing the scriptable Objects the enemy will use. Imagebehavior's here to keep the UI Healthbar up to date.
    public UnityEvent dieEvent, attackEvent,noAttackEvent,damageEvent, EnableEvent,RespawnEvent;
    public FloatData bipedMaxHp, EnCurrentHp,enpassHP,deadPassHP;
    public IntData playerCurrentDamage,DangerLevel;
    public UnityAction<ImageBehavior> UpdateImage;


    [Header("Navigation")]
    public Transform playerPos; 
    private NavMeshAgent agent;
    public LayerMask Ground, Player;

    // these dictate the size of the spheres the enemy will cast to see if the player is in agro range, and attacking range
    public float sightRange, attackRange;
    public bool PlayerInSight, PlayerInAttack;
    

    public override void Start()
    {

        EnCurrentHp = ScriptableObject.CreateInstance<FloatData>();
        DangerLevel = ScriptableObject.CreateInstance<IntData>();
        // "Danger level" was from my older project, enemies would take less overall damage the higher this is. 
        DangerLevel.value = 1;
        EnCurrentHp.value = bipedMaxHp.value;
        agent = GetComponent<NavMeshAgent>();
        playerPos = GameObject.Find("Player").transform;
        
        //bad code here, set this true so enemies wouldn't lose the player in a combat arena, since aggro isn't really a thing for this game.
        PlayerInSight = true;
        
    }

    //depreciated functions, also holdover from older games. 
    public override void Wander()
    {
        
    }

    public override void SearchWalkPoint()
    {
    }
    

    //this sets whatever object is tagged as player as the target to chase & attack 
    public override void Hunt()
    {
        agent.SetDestination(playerPos.position);
    }

    //if the player is in range of the enemy's attack sphere, it stops in place, and calls for the attack animation to start.
    public override void Attack()
    {
        agent.SetDestination(transform.position);
        print("Player in range!");
        attackEvent.Invoke();
    }

    //this basically runs math to check the player's attacking SO, and subtract that number from the enemy's current health. if enemy health is 0, then call the dying event/ animation
    public override void TakeDamage()
    {
        PlayerInSight = true;
        //Danger level in action, lowering the incoming damage from the player.
        EnCurrentHp.value -= (playerCurrentDamage.value/(DangerLevel.value));
        //the floating enemy healthbars use a "passing" floatdata object to hand off the enemy's current health to the UI system. unity wasn't cooperating when I tried to send it directly from a given enemy. ¯\_(ツ)_/¯
        enpassHP.value = EnCurrentHp.value;
        damageEvent.Invoke();
        if (EnCurrentHp.value <= 0)
        {
            Die();
        }
    }

        //more holdover code, lets an enemy regenerate HP at a hardcoded rate until it's back to full, then revives. could be usefull for a perpetually healing enemy, but would need some refactoring
    public override void Regen()
    {
        if (EnCurrentHp.value >= bipedMaxHp.value)
        {
            Respawn();
        }
        EnCurrentHp.value += 2;
        deadPassHP.value = EnCurrentHp.value;
    }

    public override void Die()
    {
        dieEvent.Invoke();
    }

    //calls a "reviving" animation, and increases the enemy's danger level. again could be cool, but It'd be better to just have armored enemies w/ a set damage reduction IMO
    public override void Respawn()
    {
        RespawnEvent.Invoke();
        DangerLevel.value++;
    }

    //the way this code works, the "thinking" and player targeting handled here, and the forward movement is handled by animations & navmesh agents.  
    
    //Every coroutine "tic" the enemy locates the player, and checks to see if it needs to rotate to point towards them.
    //if player's in reach, stop moving & start attacking. 
    public void Think()
    {
        
        PlayerInAttack = Physics.CheckSphere(transform.position, attackRange,Player);
        
        //If the player's in sight, chase (they're always in sight thanks to the lazy hardcoding in start)
        if (PlayerInSight)
        {
            noAttackEvent.Invoke();
            
            Hunt();
            
        }
        //if player's in reach, stop moving & start attacking. 
        if (PlayerInAttack)
        {
            attackEvent.Invoke();
            
            //Hunt();
        }
        else
        //otherwise, don't call any new animations, and keep chasing the player
        {
            noAttackEvent.Invoke();
        }

    }

    //whenever an enemy is enabled in unity, it refreshes it's health to full, and starts up the coroutine that handles thinking.
    public void OnEnable()
    {
        EnCurrentHp.value = bipedMaxHp.value;
        EnableEvent.Invoke();
    }

    //fun trick I learned. this generates spheres in editor, so you can see the enemy's sight and attack ranges as you modify them.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }
}
