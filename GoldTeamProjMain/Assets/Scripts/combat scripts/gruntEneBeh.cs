using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class gruntEneBeh : MonoBehaviour
{
    public GameObject parent;
    
    [Header("check this if this enemy is suppose to patrol an area")]
    public bool PatrolingEnemy;
    
    [Header("locations in order for patrol route")]
    public List<Vector3> points;

    [Header("pls ignore it needs to be public for math")]
    public List<Vector3> editPoints;
    
    public UnityEvent atkEv;

    private NavMeshAgent agent;
    private bool currentlyPatroling;
    private WaitForSeconds delay;
    private Transform playerPos,startLoc;
    private int looping;
    
    // Start is called before the first frame update
    void Start()
    {
        editPoints.Clear();
        agent=GetComponent<NavMeshAgent>();
        delay = new WaitForSeconds(1f);
        playerPos = GameObject.Find("Player").transform;
        startLoc = gameObject.transform;//patroling enemy needs to be placed on 1st patrol point
        
        if (PatrolingEnemy==true)
        {
            looping = 0;
            foreach (var item in points)
            {//nav mesh agents dont do local vs world coords, this math will do that for us
                editPoints.Add(new Vector3((points[looping].x+parent.transform.position.x),0,(points[looping].z+parent.transform.position.z)));
                looping++;
            }
            currentlyPatroling = true;
            StartCoroutine(patrolLoop());
        }
    }

    public void attack()//called from atk range trigger
    {
        atkEv.Invoke();//use this to que up atk anims and such
        if (this.IsDestroyed()==false) //if we are dead stop working)
        {
            agent.isStopped = true;//stop moving
        }
        
    }
    public void hunt()//called from camp to go get player
    {
        StopCoroutine(patrolLoop());
        if (this.IsDestroyed()==false) //if we are dead stop working)
        {
            agent.isStopped = false;
            agent.SetDestination(playerPos.position);
            if (PatrolingEnemy==true)
            {
                currentlyPatroling = false;
            }
        }
        
    }

    public void goHome()
    {
        if (this.IsDestroyed()==false) //if we are dead stop working)
        {
            agent.isStopped = false;
            agent.SetDestination(startLoc.position);
            if (PatrolingEnemy == true)
            {
                currentlyPatroling = true;
                StartCoroutine(patrolLoop());
            }
        }
        
    }
    

    private IEnumerator patrolLoop()
    {
        if (this.IsDestroyed()==true) //if we are dead stop working
        {
            yield break;
        }
        looping = 0;
        while (currentlyPatroling==true)
        {
            if (agent.hasPath==false)
            {
                if (this.IsDestroyed()==false) //if we are dead stop working
                {
                    agent.SetDestination(editPoints[looping]);
                }
                looping++;
                if (looping>=points.Count)
                {   //reset at the end of the list
                    looping = 0;
                }
            }
            yield return delay;
        }
        yield return delay;
    }
    
}
