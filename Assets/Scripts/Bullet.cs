using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Collider2D originCollider;
    private float lifetime = 2f;
    public int damage;
    public Vector2 velocity = Vector2.zero;
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0f)
        {
            Destroy(gameObject);
        }
        transform.position += (transform.right * 8f + new Vector3(velocity.x, velocity.y, 0)) * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider == originCollider)
        {
            return;
        }
        Debug.Log("ddd");
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.Damage(damage);
        }
        Destroy(gameObject);
    }
}
