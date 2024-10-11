using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    public bool detectEnemy;

    public float fireCooldown = 1;
    float countdown = 0f;
    bool canFire = false;

    public float projectileDamage = 1f;
    public float projectileSpeed = 2f;

    [SerializeField] Transform parent;

    private void Update()
    {
        FireCheck();

        if (detectEnemy && canFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
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
}
