using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceShipMovment : MonoBehaviour
{
    [Header("Movement Input")]
    [SerializeField] float thrustSpeed = 10f;
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] float boostPower = 10f;
    [SerializeField] float dampeningFactor = 0.98f;

    [SerializeField] float rotationLockDuration = 0.5f;
    [SerializeField] float thrustinputWindow = 0.3f;

    private Vector2 velocity;
    private Vector2 position;

    private bool lockRotation = false;

    private CharacterController controller;
    Vector2 rotationvector;
    bool isThrusting;

    float ThrustTimer = 0f;
    float rotationLockTimer = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        position = transform.position;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (rotationLockTimer <= rotationLockDuration) return;
        Vector2 input = context.ReadValue<Vector2>();
        if (input != Vector2.zero) rotationvector = input;
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
                float rotationAngle = Mathf.Atan2(rotationvector.y, rotationvector.x) * Mathf.Rad2Deg;
                velocity += new Vector2(transform.right.x, transform.right.y) * boostPower;
                rotationLockTimer = 0f;
                ThrustTimer = 0f;
            }
            isThrusting = false;
        }
    }

    void Update()
    {
        ThrustTimer += Time.deltaTime;
        rotationLockTimer += Time.deltaTime;
        float targetRotationAngle = Mathf.Atan2(rotationvector.y, rotationvector.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, targetRotationAngle), rotationSpeed * Time.deltaTime);

        if (isThrusting)
        {
            velocity += new Vector2(transform.right.x, transform.right.y) * thrustSpeed * Time.deltaTime;
        }

        velocity *= dampeningFactor;

        position += velocity * Time.deltaTime;

        transform.position = position;
    }
}
