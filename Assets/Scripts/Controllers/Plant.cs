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
    private Vector2 _bulletMoveDirection;

    private Transform _parent;
    private PlantController _parentPlantController;

    private string _plantType;
    
    //Initialise and assign variables

    private void Awake()
    {
        _parentPlantController = transform.parent.transform.parent.GetComponent<PlantController>();
        _plantSprite = GetComponent<SpriteRenderer>();
        //Get the SpriteRenderer component of this plant
    }
    
    private void Start()
    {
        _parent = transform.parent.transform;
    }

    private void Update()
    {
        _plantSprite.sprite = _sprite;
        //Set the correct sprite

        FireCheck();
        //Check if the plant can fire a projectile

        GameObject bullet = null;
        
        if(_canFire && (detectEnemy || _plantType == "Sunflower")) {bullet = Instantiate(_bulletGo, transform.position + new Vector3(0, Random.Range(-.4f, .4f), 0), Quaternion.identity);}
        
        if (_plantType == "Peashooter" && bullet)
        {
            //If the bullet spawned is a Bullet, set the projectile damage and speed
            Bullet bulletComp = bullet.GetComponent<Bullet>();
            bulletComp.projectileDamage = projectileDamage;
            bulletComp.projectileSpeed = projectileSpeed;
            bulletComp.moveDirection = _bulletMoveDirection;
        }
        else if (_plantType == "Sunflower" && bullet)
        {
            //If the bullet spawned is a Sun, set the sun to be spawned by a sunflower instead
            bullet.GetComponent<Sun>().spawnedBySunflower = true;
        }
    }

    private void FireCheck()
    {
        detectEnemy = _parent.CompareTag("ZombieDetected");
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
        _plantType = type;
        
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

        switch (_parentPlantController.player)
        {
            case 1:
                _plantSprite.flipX = false;
                transform.Rotate(0,0,0);
                _bulletMoveDirection = Vector2.right;
                break;
            case 2:
                _plantSprite.flipX = true;
                transform.Rotate(0,0,0);
                _bulletMoveDirection = Vector2.left;
                break;
            case 3:
                _plantSprite.flipX = true;
                transform.Rotate(0,0,90);
                _bulletMoveDirection = Vector2.down;
                break;
            case 4:
                _plantSprite.flipX = false;
                transform.Rotate(0,0, 90);
                _bulletMoveDirection = Vector2.up;
                break;
        }
    }
}
