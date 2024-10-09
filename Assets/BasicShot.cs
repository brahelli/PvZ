using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    [SerializeField] bool detectEnemy;

    public float fireCooldown = 1;
    float countdown = 0f;
    bool canFire = false;

    private void Update()
    {
        if(Time.time > countdown)
        {
            canFire = true;
            countdown = Time.time + fireCooldown;
        }
        else
        {
            canFire = false;
        }

        if (detectEnemy && canFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}
