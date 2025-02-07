using UnityEngine;
using UnityEngine.Serialization;

public class Zombie : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float damage = 1f;
    public float health = 7f;

    [SerializeField] private float attackTime = 1;
    private float _nextAttackTime = 0;

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

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Plant") && _nextAttackTime <= Time.time)
        {
            other.GetComponent<Plant>().Damage(damage);
            _nextAttackTime = Time.time + attackTime;
        }
    }
}
