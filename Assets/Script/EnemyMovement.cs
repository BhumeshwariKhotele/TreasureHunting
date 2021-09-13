using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    Animator anim;
    Aggro_Detection aggro;
    NavMeshAgent nav;
    Transform enemyTarget;
    public GameObject[] goals;
    Vector3 lastgoal;
    public float chasingPoint;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        aggro = GetComponent<Aggro_Detection>();
        aggro.OnAggro += Aggro_OnAggro;
    }


    private void Aggro_OnAggro(Transform target)
    {
        this.enemyTarget = target;
    }

    public void SetLocation()
    {
        nav.SetDestination(goals[Random.Range(0, goals.Length)].transform.position);
        anim.SetBool("isRun", true);
    }

    private void Update()
    {
        if (enemyTarget != null)
        {
            nav.SetDestination(enemyTarget.position);
            float enemySpeed = nav.velocity.magnitude;
            anim.SetBool("isRun", true);
        }
        if (nav.remainingDistance < 3)
        {
            SetLocation();
        }

    }
}
/*
{ 
  
// Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) < chasingPoint)
        {
            enemyScript.enabled = true;
        }
        else
        {
            enemyScript.enabled = false;
        }
       
    }
}*/