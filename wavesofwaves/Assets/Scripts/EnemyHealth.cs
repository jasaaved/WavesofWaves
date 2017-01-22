using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public int health;
    public int maxHealth;
    public GameObject explosionParticle;
    private GameObject particleInstance;
    public AudioClip deathSound;

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

        particleInstance = Instantiate(explosionParticle, transform.position, Quaternion.identity);
        if (deathSound)
        {
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, .3f);
        }

        GameManager.Instance.AddScore(100);
        GameManager.Instance.enemies.Remove(this);
        GameManager.Instance.CheckEnemies();
 
        //Camera.main.GetComponent<CameraShaking>().Shake(0.3f, 0.3f);
        Destroy(gameObject);
    }
}
