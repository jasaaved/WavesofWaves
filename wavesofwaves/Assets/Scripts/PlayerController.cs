using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Components
    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Animator anim;                      // Reference to the animator component.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    private PlayerController playerController;
    int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    float camRayLength = 100f;          // The length of the ray from the camera into the scene.

    // Movement
    public float speed = 6f;            // The speed that the player will move at.
    public float xVelAdj;
    public float yVelAdj;
    private float xFire;
    private float yFire;

    // Abilities
    public float waterCooldown = 1f;
    public float airCooldown = 1f;
    public float lightCooldown = 1f;
    public GameObject Airblast;
    public GameObject Waterwave;
    public GameObject Lightwave;
    private float airTimer;
    [HideInInspector]
    public float waterTimer;
    private float lightTimer;

    void Awake()
    {
        // Create a layer mask for the floor layer.
        floorMask = LayerMask.GetMask("Floor");
        // Set up references.
        playerRigidbody = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        airTimer = 0;
        waterTimer = 0;
        lightTimer = 0;
    }

    void FixedUpdate()
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

    private void Update()
    {
        // Actviate air ability
        if ((Mathf.Abs(xFire) > 0.2 || Mathf.Abs(yFire) > 0.2) && airTimer <= 0)
        {
            AirBlast();
            airTimer = airCooldown;
        }
        // Activate water ability
        if (waterTimer <= 0 && Input.GetButtonDown("Fire2"))
        {
            WaterWave();
            waterTimer = waterCooldown;
        }
        // Activate light ability
        if (lightTimer <= 0 && Input.GetButtonDown("Fire3"))
        {
            LightWave();
            lightTimer = 3f;
        }
        airTimer -= Time.deltaTime;
        waterTimer -= Time.deltaTime;
        lightTimer -= Time.deltaTime;
    }

    void Move(float h, float v, float xs, float ys)
    {
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

    void AirBlast()
    {
        GameObject.Instantiate(Airblast, transform.position, transform.rotation);
    }

    void WaterWave()
    {
        GameObject.Instantiate(Waterwave);
    }

    void LightWave()
    {
        GameObject.Instantiate(Lightwave, transform.position + transform.forward * 5, transform.rotation);
    }
}
