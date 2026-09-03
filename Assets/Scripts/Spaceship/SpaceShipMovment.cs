using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceShipMovment : MonoBehaviour
{
    [Header("Movement changes")]
    [SerializeField] private float thrustSpeed = 10f;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float rotationAmount = 90f;
    [SerializeField] private float boostPower = 10f;
    [SerializeField] private float dampeningFactor = 0.98f;

    [SerializeField] private float rotationLockDuration = 0.5f;
    [SerializeField] private float thrustinputWindow = 0.3f;

    [Header("Inputs")]
    [SerializeField] private Boosts boostmanager;

    [SerializeField] private ParticleSystem thrustparticle;

    public Vector2 velocity;

    private float targetRotationAngle = 0;

    private float collisionCheckY = 10f;
    private float collisionCheckX = 10f;

    private CharacterController controller;
    Vector2 rotationvector;
    bool isThrusting;
    private Collision2D collidingObject;

    private bool turnRight = false;
    private bool turnLeft = false;

    float ThrustTimer = 0f;
    float rotationLockTimer = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        collisionCheckY = Camera.main.orthographicSize;
        collisionCheckX = Camera.main.orthographicSize * Screen.width / Screen.height;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (rotationLockTimer <= rotationLockDuration) return;
        Vector2 input = context.ReadValue<Vector2>();
        if (input != Vector2.zero) rotationvector = input;
    }

    public void OnRotateRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            turnRight = true;
        }
        if (context.canceled)
        {
            turnRight = false;
        }
    }

    public void OnRotateLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            turnLeft = true;
        }
        if (context.canceled)
        {
            turnLeft = false;
        }
    }

    public void OnThrust(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isThrusting = true;
            ThrustTimer = 0f;
        }
        if (context.canceled)
        {
            if (ThrustTimer < thrustinputWindow)
            {
                if (boostmanager.UseBoost())
                {
                    float rotationAngle = Mathf.Atan2(rotationvector.y, rotationvector.x) * Mathf.Rad2Deg;
                    velocity += new Vector2(transform.right.x, transform.right.y) * boostPower;
                    rotationLockTimer = 0f;
                }
            }

            ThrustTimer = 0f;
            isThrusting = false;
        }
    }

    void Update()
    {
        ThrustTimer += Time.deltaTime;
        rotationLockTimer += Time.deltaTime;
        //float targetRotationAngle = Mathf.Atan2(rotationvector.y, rotationvector.x) * Mathf.Rad2Deg;

        if (turnRight && rotationLockTimer >= rotationLockDuration)
        {
            targetRotationAngle = (targetRotationAngle + rotationAmount) % 360;
        }
        else if (turnLeft && rotationLockTimer >= rotationLockDuration)
        {
            targetRotationAngle = (targetRotationAngle - rotationAmount) % 360;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, targetRotationAngle), rotationSpeed * Time.deltaTime);

        if (isThrusting)
        {
            velocity += new Vector2(transform.right.x, transform.right.y) * thrustSpeed * Time.deltaTime;
            ParticleSystem.EmissionModule emission = thrustparticle.emission;
            emission.enabled = true;
        }
        else
        {
            ParticleSystem.EmissionModule emission = thrustparticle.emission;
            emission.enabled = false;
        }

        velocity *= dampeningFactor;

        velocity = CollisionCheck(velocity);

        transform.position += new Vector3(velocity.x, velocity.y, 0) * Time.deltaTime;
    }

    private Vector2 CollisionCheck(Vector2 velocity)
    {
        if (transform.position.y > collisionCheckY)
        {
            if (velocity.y < 0) return velocity;
            velocity = new Vector2(velocity.x, -velocity.y);
            velocity += new Vector2(0, -1);
        }
        else if (transform.position.y < -collisionCheckY)
        {
            if (velocity.y > 0) return velocity;
            velocity = new Vector2(velocity.x, -velocity.y);
            velocity += new Vector2(0, 1);
        }
        else if (transform.position.x > collisionCheckX)
        {
            if (velocity.x < 0) return velocity;
            velocity = new Vector2(-velocity.x, velocity.y);
            velocity -= new Vector2(0, 1);
        }
        else if (transform.position.x < -collisionCheckX)
        {
            if (velocity.x > 0) return velocity;
            velocity = new Vector2(-velocity.x, velocity.y);
            velocity -= new Vector2(0, 1);
        }
        return velocity;
    }

    // draw collision border XD (only think i thought i should comment)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector2.zero, new Vector3(collisionCheckX * 2, collisionCheckY * 2, 0));
    }

    public void ResetMovement(Vector3 startPosition)
    {
        velocity = Vector2.zero;
        transform.position = startPosition;

        rotationvector = Vector2.zero;
        isThrusting = false;
    }
}
