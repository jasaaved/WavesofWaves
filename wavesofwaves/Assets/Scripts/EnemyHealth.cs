using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameManager.Instance.enemies.Add(this);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Death()
    {
        GameManager.Instance.enemies.Remove(this);
        GameManager.Instance.CheckEnemies();
        Destroy(gameObject);
    }
}
