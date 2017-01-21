using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour {

    /// <summary>
    /// This is a general death script that's used with hazards. 
    /// </summary>
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        // If whatever's colliding with the hazard has a tag of "Player" or
        // "Enemy", it kills/destroys that thing.

        if (collision.gameObject.CompareTag("Player")) 
        {
            collision.gameObject.GetComponent<PlayerHealth>().Death();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().Death();
        }
    }
}
