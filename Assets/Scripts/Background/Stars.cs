using UnityEngine;

public class Stars : MonoBehaviour
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
        float y = Mathf.Sin(Time.time * speed) * distance;

        transform.position = startPosition + new Vector3(0f, y, 0f);
    }
}
