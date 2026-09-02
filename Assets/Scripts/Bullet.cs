using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float lifetime = 2f;
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0f)
        {
            Destroy(gameObject);
        }
        transform.position += transform.up * Time.deltaTime * 8f;
    }
}
