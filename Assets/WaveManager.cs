using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour
{ 
    
    [SerializeField] private GameObject zombie;

    private void Start()
    {
        StartCoroutine(StartSpawning());
    }

    private IEnumerator StartSpawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            Instantiate(zombie, new Vector2(Random.Range(6.33f, 11.36f), Random.Range(-1.5f, 3f)), Quaternion.identity);
        }
    }
}
