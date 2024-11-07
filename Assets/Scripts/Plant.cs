using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] GameObject[] availableProjectiles;
    [SerializeField] Sprite[] availableSprites;
    Sprite sprite;

    GameObject bulletGO;
    SpriteRenderer plantSprite;
    
    public bool detectEnemy;

    public float fireCooldown = 1;
    float countdown = 0f;
    bool canFire = false;

    public float projectileDamage = 1f;
    public float projectileSpeed = 2f;

    [SerializeField] Transform parent;

    private void Start()
    {
        plantSprite = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        plantSprite.sprite = sprite;

        FireCheck();

        if (detectEnemy && canFire)
        {
            GameObject bullet = Instantiate(bulletGO, transform.position + new Vector3(0, Random.Range(-.4f, .4f), 0), Quaternion.identity);
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

    void FireCheck()
    {
        if (parent.tag == "ZombieDetected")
        {
            detectEnemy = true;
        }
        else
        {
            detectEnemy = false;
        }

        if (Time.time > countdown)
        {
            canFire = true;
            countdown = Time.time + fireCooldown;
        }
        else
        {
            canFire = false;
        }
    }

    public void SetType(string type)
    {
        switch (type)
        {
            case "Peashooter":
                bulletGO = availableProjectiles[0];
                sprite = availableSprites[0];
                break;
            case "Sunflower":
                bulletGO = availableProjectiles[1];
                sprite = availableSprites[1];
                break;
        }
    }
}
