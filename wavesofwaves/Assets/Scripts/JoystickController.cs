using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JoystickController : MonoBehaviour
{
    public float speed = 10f;            // The speed that the player will move at.

    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    private float attackTimer;
    public float xVelAdj;
    public float yVelAdj;
    private float xFire;
    private float yFire;
    public GameObject Airblast;

    void Awake()
    {
        // Set up references.
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        attackTimer = 0;
    }


    void FixedUpdate()
    {
        xVelAdj = Input.GetAxis("xMove");
        yVelAdj = Input.GetAxis("yMove");
        xFire = Input.GetAxis("xShoot");
        yFire = Input.GetAxis("yShoot");
        Move(xVelAdj, yVelAdj, xFire, yFire);
    }

    private void Update()
    {
        if ((Mathf.Abs(xFire) > 0.2 || Mathf.Abs(yFire) > 0.2) && attackTimer <= 0)
        {
            AirBlast();
            attackTimer = 1f;
        }
        attackTimer -= Time.deltaTime;
    }

    void Move(float h, float v, float xs, float ys)
    {
        /*
        //Does not work
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
        */
        playerRigidbody.velocity = new Vector3(speed * h, 0, speed * v);
        float heading = Mathf.Atan2(xs, ys);
        transform.rotation = Quaternion.EulerAngles(0, heading, 0);
    }

    void AirBlast()
    {
        GameObject.Instantiate(Airblast, transform.position, transform.rotation);
    }
}
