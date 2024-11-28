using UnityEngine;

public class BasicShot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    [SerializeField] private bool detectEnemy;

    public float fireCooldown = 1;
    private float _countdown = 0f;
    private bool _canFire = false;

    private void Update()
    {
        if (Time.time > _countdown)
        {
            _canFire = true;
            _countdown = Time.time + fireCooldown;
        }
        else
        {
            _canFire = false;
        }

        if (detectEnemy && _canFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}
