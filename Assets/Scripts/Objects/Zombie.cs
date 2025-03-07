using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float damage = 1f;
    public float health = 10f;

    [SerializeField] private float attackTime = 3;
    private float _nextAttackTime;

    private Rigidbody2D _rb;

    private Animator _anim;
    
    private GameManager _gameManager;
    
    private Vector2 _direction;
    
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    [SerializeField] private Sprite[] sprites;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        int randomDirection = 0;
        RandomZombie();

        switch (_gameManager.noOfPlayers)
        {
            case 1:
                randomDirection = 1;
                break;
            case 2:
                randomDirection = Random.Range(1, 3);
                break;
            case 3:
                randomDirection = Random.Range(1, 4);
                break;
            case 4:
                randomDirection = Random.Range(1, 5);
                break;
        }

        switch (randomDirection)
        {
            case 1:
                transform.rotation = Quaternion.identity;
                spriteRenderer.flipX = false;
                _direction = Vector2.left;
                break;
            case 2:
                transform.rotation = Quaternion.identity;
                spriteRenderer.flipX = true;
                _direction = Vector2.right;
                break;
            case 3:
                transform.rotation = Quaternion.Euler(0, 0, 270);
                spriteRenderer.flipX = false;
                _direction = Vector2.up;
                break;
            case 4:
                transform.rotation = Quaternion.Euler(0, 0, 270);
                spriteRenderer.flipX = true;
                _direction = Vector2.down;
                break;
        }
    }

    private void Update()
    {
        _rb.MovePosition(_rb.position + _direction * (moveSpeed * Time.deltaTime));
    }

    public void DealDamage(float damageBy)
    {
        health -= damageBy;
        
        if (health <= 0) { Die(); }
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
    
    private void RandomZombie()
    {
        int randomZombie = Random.Range(0, sprites.Length);

        switch (randomZombie)
        {
            case 0:
                health = 10f;
                break;
            case 1:
                health = 15f;
                break;
        }
        spriteRenderer.sprite = sprites[randomZombie];
    }
}
