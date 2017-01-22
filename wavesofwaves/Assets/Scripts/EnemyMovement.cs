using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;              // Reference to the player's position.
    [HideInInspector]
    public NavMeshAgent nav;               // Reference to the nav mesh agent.
    private float maxSpeed;
    [HideInInspector]
    public bool slowed;
    [HideInInspector]
    public float ccTimer;
    [HideInInspector]
    public bool stunned;
    [HideInInspector]
    public bool confused;
    [HideInInspector]
    public Vector3 randomDestination;

    void Awake ()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        nav = GetComponent <NavMeshAgent> ();
        maxSpeed = nav.speed;
        ccTimer = 0;
        slowed = false;
        stunned = false;
        confused = false;
    }


    void Update ()
    {
        // TODO: Check for isAlive and disable if dead
        if (!GameManager.Instance.enemiesDisabled)
        {
            if (nav.isActiveAndEnabled)
            {
                nav.SetDestination(player.position);
            }
            if (ccTimer > 0 && slowed && !stunned)
            {
                nav.speed = 1.5f;
            }
            else if (ccTimer > 0 && stunned)
            {
                nav.speed = 0f;
                nav.enabled = false;
            }
            else if (ccTimer <= 0)
            {
                nav.enabled = true;
                nav.speed = maxSpeed;
                stunned = false;
                slowed = false;
                confused = false;
            }

            if (ccTimer > 0 && confused && !stunned)
            {
                nav.SetDestination(randomDestination);
            }
            ccTimer -= Time.deltaTime;
            Debug.Log(ccTimer);
        }
    } 

    public Vector3 RandomDestination()
    {
        return new Vector3(Random.Range(-40, 40), 2.6f, Random.Range(-40, 40));
    }
}