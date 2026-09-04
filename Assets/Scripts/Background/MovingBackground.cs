using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;
    [SerializeField] private float distance = 0.5f;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float x = Mathf.Sin(Time.time * speed) * distance;

        transform.position = startPosition + new Vector3(x, 0f, 0f);
    }
}
