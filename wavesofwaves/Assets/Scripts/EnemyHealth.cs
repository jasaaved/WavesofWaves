using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public int health;
    public int maxHealth;

    // Use this for initialization
    void Start () {
        GameManager.Instance.enemies.Add(this);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        GameManager.Instance.enemies.Remove(this);
        GameManager.Instance.CheckEnemies();
        Destroy(gameObject);
    }
}
