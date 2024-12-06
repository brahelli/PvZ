using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Plant : MonoBehaviour
{
    [SerializeField] private GameObject[] availableProjectiles;
    [SerializeField] private Sprite[] availableSprites;
    private Sprite _sprite;

    private GameObject _bulletGo;
    private SpriteRenderer _plantSprite;
    
    public bool detectEnemy;

    public float fireCooldown = 1;
    private float _countdown;
    private bool _canFire;

    public float projectileDamage = 1f;
    public float projectileSpeed = 2f;

    [SerializeField] private Transform parent;
    
    //Initialise and assign variables

    private void Start()
    {
        _plantSprite = this.gameObject.GetComponent<SpriteRenderer>();
        //Get the SpriteRenderer component of this plant
    }

    private void Update()
    {
        _plantSprite.sprite = _sprite;
        //Set the correct sprite

        FireCheck();
        //Check if the plant can fire a projectile

        if (!detectEnemy || !_canFire) return;
        //If the plant cannot detect an enemy or cannot fire a projectile, return and do nothing
        
        GameObject bullet = Instantiate(_bulletGo, transform.position + new Vector3(0, Random.Range(-.4f, .4f), 0), Quaternion.identity);
        //Instantiate a new bullet at the plant's position with a slight random offset on the y-axis
        
        if (bullet.GetComponent<Bullet>() is not null)
        {
            //If the bullet spawned is a Bullet, set the projectile damage and speed
            bullet.GetComponent<Bullet>().projectileDamage = projectileDamage;
            bullet.GetComponent<Bullet>().projectileSpeed = projectileSpeed;
        }
        else if (bullet.GetComponent<Sun>() is not null)
        {
            //If the bullet spawned is a Sun, set the sun to be spawned by a sunflower instead
            bullet.GetComponent<Sun>().spawnedBySunflower = true;
        }
    }

    private void FireCheck()
    {
        detectEnemy = parent.CompareTag("ZombieDetected");
        //Check if the parent object is a zombie, and set detectEnemy to true if it is

        if (Time.time > _countdown)
        {
            //If the current time is greater than the countdown time, the plant can fire
            _canFire = true;
            _countdown = Time.time + fireCooldown;
            //Generate a new countdown time
        }
        else
        {
            _canFire = false;
            //If the current time is not greater than the countdown time, the plant cannot fire
        }
    }

    public void SetType(string type)
    {
        switch (type)
        {
            //Depending on the type of plant, set the bullet and sprite to the correct ones
            case "Peashooter":
                _bulletGo = availableProjectiles[0];
                _sprite = availableSprites[0];
                break;
            case "Sunflower":
                _bulletGo = availableProjectiles[1];
                _sprite = availableSprites[1];
                break;
        }
    }
}
