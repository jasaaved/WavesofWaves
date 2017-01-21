using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float xValAdj;
    public float yValAdj;
    public float xFire;
    public float yFire;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        xValAdj = Input.GetAxis("xMove");
        yValAdj = Input.GetAxis("yMove");

        GetComponent<Rigidbody>().velocity = new Vector3(3 * xValAdj, 0, 3 * yValAdj);
	}
}
