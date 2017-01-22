using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInRange : MonoBehaviour {

    public int enemiesInRange;
    public int maxEnemies;
    public float slow = -1f;
    private PlayerHealth health;
    private PlayerController playerController;
    public AudioClip ropeSound;
    public AudioClip snapRope;

	// Use this for initialization
	void Start () {
        health = GetComponentInParent<PlayerHealth>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.Instance.isGameOver)
        {
            Destroy(gameObject);
        }
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

            if (ropeSound)
            {
                AudioSource.PlayClipAtPoint(ropeSound, Camera.main.transform.position);
            }
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
            if (snapRope)
            {
                AudioSource.PlayClipAtPoint(snapRope, Camera.main.transform.position);
            }
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
