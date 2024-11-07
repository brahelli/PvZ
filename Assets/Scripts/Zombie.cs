using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float damage = 1f;
    public float health = 7f;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.MovePosition(rb.position + Vector2.left * moveSpeed * Time.deltaTime);

        if (health <= 0) { Die(); }
    }

    public void DealDamage(float damage)
    {
        health -= damage;
    }

    public void Die()
    {
        moveSpeed = 0;
        Destroy(gameObject, 1f);
    }
}
