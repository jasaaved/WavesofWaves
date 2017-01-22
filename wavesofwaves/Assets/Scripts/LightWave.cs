using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWave : MonoBehaviour {

    private GameObject player;
    private Light glow;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        glow = GetComponent<Light>();
        Destroy(this.gameObject, 0.5f);
        glow.intensity = 0;
    }

    private void Update()
    {
        glow.intensity += Time.deltaTime * 16;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            EnemyMovement enemy = other.GetComponent<EnemyMovement>();
            enemy.confused = true;
            enemy.ccTimer = 3f;
            enemy.nav.SetDestination(enemy.RandomDestination());
        }
    }
}
