using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;               // Reference to the player's position.
    private NavMeshAgent nav;               // Reference to the nav mesh agent.
    [HideInInspector]
    public bool slowed;
    [HideInInspector]
    public float ccTimer;
    [HideInInspector]
    public bool stunned;

    void Awake ()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        nav = GetComponent <NavMeshAgent> ();
        ccTimer = 0;
        slowed = false;
        stunned = false;
    }


    void Update ()
    {
        // TODO: Check for isAlive and disable if dead
        nav.SetDestination (player.position);
        if(ccTimer > 0 && slowed && !stunned)
        {
            ccTimer -= Time.deltaTime;
            nav.speed = 1.5f;
        }
        else if(ccTimer > 0 && stunned)
        {
            ccTimer -= Time.deltaTime;
            nav.speed = 0f;
        }
    } 
}