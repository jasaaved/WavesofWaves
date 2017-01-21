using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JoystickController : MonoBehaviour
{
    public float speed = 10f;            // The speed that the player will move at.
    public float airCooldown = 1f;

    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    public int floorMask;
    float camRayLength = 100f;
    private float attackTimer;
    private float airTimer;
    public float xVelAdj;
    public float yVelAdj;
    private float xFire;
    private float yFire;
    public GameObject Airblast;
    private PlayerController playerController;

    void Awake()
    {
        // Set up references.
        playerRigidbody = GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("Floor");
    }

    private void Start()
    {
        attackTimer = 0;
        airTimer = 0;
        playerController = GetComponent<PlayerController>();
    }


    void FixedUpdate()
    {
        if (!GameManager.Instance.isGameOver)
        {
            xVelAdj = Input.GetAxis("xMove");
            yVelAdj = Input.GetAxis("yMove");

            if (Input.GetAxisRaw("xMoveKey") != 0 || Input.GetAxisRaw("yMoveKey") != 0)
            {
                xVelAdj = Input.GetAxisRaw("xMoveKey");
                yVelAdj = Input.GetAxisRaw("yMoveKey");
            }
            if (!GameManager.Instance.isUsingMouse && playerController.waterTimer <= 0)
            {
                xFire = Input.GetAxis("xShoot");
                yFire = Input.GetAxis("yShoot");
            }
            else
            {
                Turning();
            }

            Move(xVelAdj, yVelAdj, xFire, yFire);
        }
    }

    void Turning()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    private void Update()
    {

        if ((Mathf.Abs(xFire) > 0.2 || Mathf.Abs(yFire) > 0.2) && airTimer <= 0)
        {
            AirBlast();
            airTimer = airCooldown;
        }
        airTimer -= Time.deltaTime;
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
        if (playerController.waterTimer <= 0)
        {
            float heading = Mathf.Atan2(xs, ys);
            if (!GameManager.Instance.isUsingMouse)
            {
                transform.rotation = Quaternion.EulerAngles(0, heading, 0);
            }
        }
    }

    void AirBlast()
    {
        GameObject.Instantiate(Airblast, transform.position, transform.rotation);
    }
}
