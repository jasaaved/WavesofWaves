using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBlast : MonoBehaviour
{
    public float speed = 10f;
    public float force = 1000f;

    private Vector3 trajectory;
    private Rigidbody m_Rigidbody;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        trajectory = player.transform.forward;
        m_Rigidbody = GetComponent<Rigidbody>();
        transform.Rotate(new Vector3(0, 270, 0));
        transform.Translate(new Vector3(trajectory.x + 1, trajectory.y, trajectory.z - 1));
    }

    private void Update()
    {
        m_Rigidbody.velocity = trajectory * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Rigidbody enemy = other.GetComponent<Rigidbody>();
            enemy.AddForce(trajectory * force);
            //Destroy(this.gameObject);
        }
        //if (other.tag == "Obstacle")
        //{
        //    Destroy(this.gameObject);
        //}
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
