using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

//this is just a butchered/edited version of jaden's EnemyBipedBehavior code
public class HunterEneBeh : MonoBehaviour
{
    [Header("if they can see you they will follow")]
    public UnityEvent atkEv,walkEv,idleEv;// use to trigger animations
    
    [Tooltip("about 3-5 less than the hunt range collider radius")]
    public float   sightRange;
    
    private Transform playerPos;
    private NavMeshAgent agent;
    private WaitForSeconds delay;
    private bool hunting;
    
    public void Start()
    {
        hunting = false;
        agent = GetComponent<NavMeshAgent>();
        playerPos = GameObject.Find("Player").transform;
        delay = new WaitForSeconds(1);
    }

    public void startHunt()
    {
        walkEv.Invoke();
        if (hunting==false)
        {
            agent.SetDestination(playerPos.position);
            StartCoroutine(Think());
        }
    }

    public void stopAll()//call this on death to help clean up
    {
        StopAllCoroutines();
        if (agent!=null)
        {
            agent.isStopped = true;
        }
    }

    public void attack()
    {
        atkEv.Invoke();//use this to que up atk anims and such
        if (this.IsDestroyed()==false) //if we are dead stop working)
        {
            agent.isStopped = true;//stop moving
        }
    }
    private IEnumerator Think()//this starts as soon as the player comes close enough for it to activate
    {
        hunting = true;
        while (Vector3.Distance(transform.position,playerPos.position)>0)//if you are not on top of player
        {
            agent.SetDestination(playerPos.position);
            if (agent.remainingDistance<sightRange)
            {   //keep moving if can still see
                    agent.isStopped = false;
            }
            else  //they have escaped stop following
            {
                idleEv.Invoke();
                hunting = false;
                break;
            }
            
            yield return delay;
        }
    }
    
    private void OnDrawGizmosSelected()//adds visuals to the editor when obj is selected
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }

}
