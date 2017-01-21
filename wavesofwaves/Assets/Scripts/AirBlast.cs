using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AirBlast : MonoBehaviour
{
    public float speed = 10f;
    public float force = 1000f;
    public float maxStunTime = 0.5f;

    private Vector3 trajectory;
    private Rigidbody m_Rigidbody;
    private GameObject player;
    private GameObject enemy;
    private float currStunTime = 0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        trajectory = player.transform.forward;
        m_Rigidbody = GetComponent<Rigidbody>();
        
        // Re-align object
        transform.Rotate(new Vector3(0, 270, 0));
    }

    private void Update()
    {
        m_Rigidbody.velocity = trajectory * speed;

        // Enemy is 'stunned' while force is applied
        //if (currStunTime > 0)
        //{
        //    currStunTime -= Time.deltaTime;
        //}
        //else if (enemy != null)
        //{
        //    enemy.GetComponent<NavMeshAgent>().enabled = true;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemy = other.gameObject;
            enemy.GetComponent<EnemyMovement>().stunned = true;
            enemy.GetComponent<EnemyMovement>().ccTimer = maxStunTime;
            enemy.GetComponent<Rigidbody>().AddForce(trajectory * force);
            currStunTime = maxStunTime;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
