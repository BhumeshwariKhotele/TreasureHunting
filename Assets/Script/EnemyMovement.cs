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


    private void Update()
    {
        if (enemyTarget != null)
        {
            nav.SetDestination(enemyTarget.position);
            float enemySpeed = nav.velocity.magnitude;
            anim.SetFloat("enemySpeed", enemySpeed);
        }

    }
}


