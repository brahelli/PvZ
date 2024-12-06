using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb;

    public float projectileSpeed = 2f;
    public float projectileDamage = 1f;

    
    //Initialise and assign variables
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 6f);
        //Get the Rigidbody2D component and destroy the bullet after 6 seconds, always. Saves on performance
    }

    private void Update()
    {
        _rb.MovePosition(_rb.position + Vector2.right * (projectileSpeed * Time.deltaTime));
        //Move the bullet to the right at a speed of projectileSpeed multiplied by Time.deltaTime to keep the bullet moving at a consistent speed across frames
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null || !collision.CompareTag("Zombie")) return;
        //If the collision is null or the object is not a zombie, return and do nothing
        Zombie zombie = collision.GetComponent<Zombie>();
        //Get the Zombie component from the collision object
        zombie.DealDamage(projectileDamage);
        //Deal damage to the zombie
        Destroy(gameObject);
        //Destroy this bullet
    }
}
