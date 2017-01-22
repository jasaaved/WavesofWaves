using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInRange : MonoBehaviour {

    public int enemiesInRange;
    public int maxEnemies;
    public float slow = -1f;
    private PlayerHealth health;
    private PlayerController playerController;

	// Use this for initialization
	void Start () {
        health = GetComponentInParent<PlayerHealth>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemiesInRange++;
            Animator enemyAnim = other.GetComponentInChildren<Animator>();
            enemyAnim.SetTrigger("Catch");
            enemyAnim.SetBool("Capturing", true);
            playerController.speed += slow;
            CheckDeath();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemiesInRange--;
            Animator enemyAnim = other.GetComponentInChildren<Animator>();
            enemyAnim.SetBool("Capturing", false);
            playerController.speed -= slow;
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
