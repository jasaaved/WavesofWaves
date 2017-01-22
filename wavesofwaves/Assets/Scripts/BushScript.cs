using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushScript : MonoBehaviour {

    
    private int timer = 0;
    private int cooldown = 3;
    

	// Use this for initialization
	void Awake () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(3);
            // TO DO: Elephant (and enemy?) gets knocked back after making contact with the bush
        }
    }
}
