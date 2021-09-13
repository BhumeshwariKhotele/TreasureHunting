using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject particleEffect;
    public int enemyHealth;
    public int currentEnemyHealth;
    public void EnemyDamage(int damage)
    {
        currentEnemyHealth += damage;
        if (currentEnemyHealth > enemyHealth)
        {
            this.gameObject.SetActive(false);
            Instantiate(particleEffect, transform.position, Quaternion.identity);

        }
    }
}
