using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    public float projectileSpeed = 2f;
    public float projectileDamage = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 6f);
    }

    private void Update()
    {
        rb.MovePosition(rb.position + Vector2.right * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.tag == "Zombie")
        {
            Zombie zombie = collision.GetComponent<Zombie>();
            zombie.DealDamage(projectileDamage);
            Destroy(gameObject);
        }
    }
}
