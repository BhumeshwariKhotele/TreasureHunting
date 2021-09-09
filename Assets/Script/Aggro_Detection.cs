using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Aggro_Detection : MonoBehaviour
{
    public event Action<Transform> OnAggro = delegate { };
    private void OnTriggerEnter(Collider other)
    {
         //print("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
        var player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            OnAggro(player.transform);
        }
    }
}