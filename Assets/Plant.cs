using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    public bool detectEnemy;

    public float fireCooldown = 1;
    float countdown = 0f;
    bool canFire = false;

    [SerializeField] Transform parent;

    private void Update()
    {
        if (Time.time > countdown)
        {
            canFire = true;
            countdown = Time.time + fireCooldown;
        }
        else
        {
            canFire = false;
        }

        if (parent.tag == "ZombieDetected")
        {
            detectEnemy = true;
        }
        else
        {
            detectEnemy = false;
        }

        if (detectEnemy && canFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}
