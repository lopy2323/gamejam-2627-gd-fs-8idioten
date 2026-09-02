using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceShipMovment : MonoBehaviour
{
    private Vector2 velocity;
    private Vector2 position;

    private CharacterController controller;
    Vector2 rotationvector;
    bool isThrusting;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        position = transform.position;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        rotationvector = context.ReadValue<Vector2>();
    }

    public void OnThrust(InputAction.CallbackContext context)
    {
        if (context.performed) // the key has been pressed
        {
            isThrusting = true;
        }
        if (context.canceled) //the key has been released
        {
            isThrusting = false;
        }
    }

    void Update()
    {
        float rotationAngle = Mathf.Atan2(rotationvector.y, rotationvector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationAngle);

        if (isThrusting)
        {
            velocity += new Vector2(Mathf.Cos(rotationAngle * Mathf.Deg2Rad), Mathf.Sin(rotationAngle * Mathf.Deg2Rad)) * 10f * Time.deltaTime;
        }

        position += velocity * Time.deltaTime;

        transform.position = position;
    }
}
