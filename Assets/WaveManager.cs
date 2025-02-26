using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private GameObject Zombie;

    private void Update()
    {
        StartCoroutine(Start());
    }

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            Instantiate(Zombie, new Vector2(Random.Range(6.33f, 11.36f), Random.Range(-1.5f, 3f)), Quaternion.identity);
        }
    }
}
