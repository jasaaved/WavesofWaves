using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;               // Reference to the player's position.
    private NavMeshAgent nav;               // Reference to the nav mesh agent.

    void Awake ()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        nav = GetComponent <NavMeshAgent> ();

    }


    void Update ()
    {
        // TODO: Check for isAlive and disable if dead
        if (!GameManager.Instance.enemiesDisabled)
        {
            nav.SetDestination(player.position);
        }
    } 
}