using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private GameObject[] availableProjectiles;
    [SerializeField] private Sprite[] availableSprites;
    private Sprite _sprite;

    private GameObject _bulletGo;
    private SpriteRenderer _plantSprite;
    
    public bool detectEnemy;

    public float fireCooldown = 1;
    private float _countdown = 0f;
    private bool _canFire = false;

    public float projectileDamage = 1f;
    public float projectileSpeed = 2f;

    [SerializeField] private Transform parent;

    private void Start()
    {
        _plantSprite = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _plantSprite.sprite = _sprite;

        FireCheck();

        if (detectEnemy && _canFire)
        {
            GameObject bullet = Instantiate(_bulletGo, transform.position + new Vector3(0, Random.Range(-.4f, .4f), 0), Quaternion.identity);
            if (bullet.GetComponent<Bullet>() != null)
            {
                bullet.GetComponent<Bullet>().projectileDamage = projectileDamage;
                bullet.GetComponent<Bullet>().projectileSpeed = projectileSpeed;
            }
            else if (bullet.GetComponent<Sun>() != null)
            {
                bullet.GetComponent<Sun>().spawnedBySunflower = true;
            }
        }
    }

    private void FireCheck()
    {
        if (parent.tag == "ZombieDetected")
        {
            detectEnemy = true;
        }
        else
        {
            detectEnemy = false;
        }

        if (Time.time > _countdown)
        {
            _canFire = true;
            _countdown = Time.time + fireCooldown;
        }
        else
        {
            _canFire = false;
        }
    }

    public void SetType(string type)
    {
        switch (type)
        {
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
