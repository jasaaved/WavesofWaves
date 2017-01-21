using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

    /// <summary>
    /// Variation of the death script for hazards. This makes an explosion. :D
    /// </summary>

    // Use this for initialization

    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {

    }

    void Explode()
    {
        // Creates the explosion, destroys the gameObject. 

        var exp = GetComponent<ParticleSystem>();
        exp.Play();
        Destroy(gameObject, exp.duration);
    }

    void OnCollisionEnter(Collision coll)
    {
        // Whatever's attached to this script explodes upon colliding with a game
        // object, and destroys both the parent and the parameter "coll." 
       
        if (coll.gameObject.CompareTag("Player") || coll.gameObject.
            CompareTag("Enemy"))
        {
            Explode();
            Destroy(coll.gameObject);
        }

    }
}