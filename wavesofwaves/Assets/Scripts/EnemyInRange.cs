using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInRange : MonoBehaviour {

    public int enemiesInRange;
    public int maxEnemies;
    private PlayerHealth health;

	// Use this for initialization
	void Start () {
        health = GetComponentInParent<PlayerHealth>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemiesInRange++;
            CheckDeath();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemiesInRange--;
        }
    }

    private void CheckDeath()
    {
        if (enemiesInRange >= maxEnemies)
        {
            health.Death();
        }
    }

}
