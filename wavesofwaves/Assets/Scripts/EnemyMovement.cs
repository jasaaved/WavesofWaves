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
    private Animator anim;
    private GameObject elephRagdoll;

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
        anim = GetComponentInChildren<Animator>();
    }


    void Update ()
    {
        if (GameManager.Instance.isGameOver)
        {
            // Follow ragdoll
            if (elephRagdoll == null)
            {
                elephRagdoll = GameObject.FindGameObjectWithTag("Ragdoll");
            }
            nav.SetDestination(elephRagdoll.transform.position);
            return;
        }

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
                DisplaySlowEffect(true);
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

                DisplaySlowEffect(false);
            }

            if (ccTimer > 0 && confused && !stunned)
            {
                nav.SetDestination(randomDestination);
            }
            ccTimer -= Time.deltaTime;
        }

        WalkingAnimation();
    } 

    public Vector3 RandomDestination()
    {
        return new Vector3(Random.Range(-40, 40), 2.6f, Random.Range(-40, 40));
    }

    void WalkingAnimation()
    {
        if (stunned)
        {
            anim.SetBool("Walking", false);
        }
        else
        {
            anim.SetBool("Walking", true);
        }
    }

    void DisplaySlowEffect(bool slow)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.name == "WaterParticle")
            {
                transform.GetChild(i).gameObject.SetActive(slow);
            }
        }
    }
}