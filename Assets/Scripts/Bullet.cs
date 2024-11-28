using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb;

    public float projectileSpeed = 2f;
    public float projectileDamage = 1f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 6f);
    }

    private void Update()
    {
        _rb.MovePosition(_rb.position + Vector2.right * (projectileSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null || !collision.CompareTag("Zombie")) return;
        Zombie zombie = collision.GetComponent<Zombie>();
        zombie.DealDamage(projectileDamage);
        Destroy(gameObject);
    }
}
