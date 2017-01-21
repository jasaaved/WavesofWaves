using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWave : MonoBehaviour {

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
        Destroy(this.gameObject, 1f);
    }

    private void Update()
    {
        //Get the degrees to set
        currentRotation += Time.deltaTime * 360;
        //Change the Euler Angles of the Quaternions
        playerRotation.eulerAngles = new Vector3(0, currentRotation, 0);
        rotation.eulerAngles = new Vector3(0, currentRotation, 0);
        //Set position
        transform.position = player.transform.position + (player.transform.forward * 12);
        //Set the rotation of player and water.
        player.transform.rotation = playerRotation;
        transform.rotation = rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            //Insert code to slow enemy here.
        }
    }


}
