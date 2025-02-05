using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float damage = 1f;
    public float health = 7f;

    private Rigidbody2D _rb;

    private Animator _anim;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        _rb.MovePosition(_rb.position + Vector2.left * (moveSpeed * Time.deltaTime));

        if (health <= 0) { Die(); }
    }

    public void DealDamage(float damageBy)
    {
        health -= damageBy;
    }

    private void Die()
    {
        moveSpeed = 0;
        _anim.SetTrigger("Die");
        Destroy(gameObject, 1.3f);
    }
}
