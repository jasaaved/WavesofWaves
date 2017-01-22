using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWave : MonoBehaviour {

    public float slowTime = 2f;
    public float spinTime;

    private GameObject player;
    private Quaternion rotation;
    private Quaternion playerRotation;
    private float currentRotation;
    private Quaternion initialRotation;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentRotation = 0;
        rotation = transform.rotation;
        playerRotation = player.transform.rotation;
        initialRotation = player.transform.rotation;
        transform.position = player.transform.position + (player.transform.forward * 12);
        Destroy(this.gameObject, 3f);
    }

    private void Update()
    {
        spinTime -= Time.deltaTime;
        if(spinTime >= 0)
        {
            //Get the degrees to set
            currentRotation += Time.deltaTime * 360;
            //Change the Euler Angles of the Quaternions
            playerRotation.eulerAngles = initialRotation.eulerAngles + new Vector3(0, currentRotation, 0);
            rotation.eulerAngles = initialRotation.eulerAngles + new Vector3(0, currentRotation, 0);
            //Set position
            transform.position = player.transform.position + (player.transform.forward * 12);
            //Set the rotation of player and water.
            player.transform.rotation = playerRotation;
            transform.rotation = rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            EnemyMovement enemy = other.GetComponent<EnemyMovement>();
            enemy.slowed = true;
            enemy.ccTimer = slowTime;
        }
    }


}
