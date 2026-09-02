using System.Runtime.CompilerServices;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    private float flightDirection;
    private float flightSpeed;
    private float rotationSpeed;

    public asteroidSpawner spawner;

    private Rigidbody2D rb;

    private bool inScreen = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rotationSpeed = Random.Range(-30f, 30f);
        rb.angularVelocity = rotationSpeed;

        flightSpeed = Random.Range(0.4f, 1f);

        float angleToCenter = GetAngleBetweenPoints(transform.position, Vector2.zero);
        flightDirection = angleToCenter + Random.Range(-40f, 40f);

        // Actually give the Rigidbody movement
        Vector2 direction = new Vector2(
            Mathf.Cos(flightDirection * Mathf.Deg2Rad),
            Mathf.Sin(flightDirection * Mathf.Deg2Rad)
        );

        int ScaleType = Random.Range(0, 10);

        if (ScaleType > 5)
        {
            transform.localScale *= Random.Range(0.8f, 1f);
        } else if (ScaleType > 1)
        {
            transform.localScale *= Random.Range(0.1f, 0.5f);
        }
        else if (ScaleType == 0)
        {
            transform.localScale *= Random.Range(1f, 2f);
        }

        rb.linearVelocity = direction * flightSpeed;
        rb.angularVelocity = rotationSpeed;
    }

    private void Update()
    {
        Vector3 screenPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (inScreen)
        {
            if (screenPosition.x < -0.1f || screenPosition.x > 1.1f || screenPosition.y < -0.1f || screenPosition.y > 1.1f)
            {
                spawner.spawnedAsteroids.Remove(gameObject);
                Destroy(gameObject);
            }
        }
        else
        {
            if (screenPosition.x > -0.1f && screenPosition.x < 1.1f && screenPosition.y > -0.1f && screenPosition.y < 1.1f)
            {
                inScreen = true;
            }
        }
    }

    private float GetAngleBetweenPoints(Vector2 point1, Vector2 point2)
    {
        return Mathf.Atan2(
            point2.y - point1.y,
            point2.x - point1.x
        ) * Mathf.Rad2Deg;
    }
}