using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBlast : MonoBehaviour
{
    private Vector3 trajectory;
    private Rigidbody m_Rigidbody;

    private void Start()
    {
        trajectory = new Vector3(0,0,1);
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
        }
        Destroy(this.gameObject);
    }
}
