using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBlast : MonoBehaviour
{
    private Vector3 trajectory;
    private Rigidbody m_Rigidbody;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Cube");
        trajectory = player.transform.forward;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        m_Rigidbody.velocity = trajectory;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Rigidbody enemy = other.GetComponent<Rigidbody>();
            enemy.AddForce(new Vector3(0, 2, 5) * 1000);
            Destroy(this.gameObject);
        }
        else if(other.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
