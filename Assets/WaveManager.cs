using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour
{ 
    
    [SerializeField] private GameObject zombie;
    [SerializeField] private GameObject sun;
    
    [SerializeField] private GameManager gameManager;

    public void StartLevel()
    {
        StartCoroutine(Level1());
    }

    private IEnumerator Level1()
    {
        yield return new WaitForSeconds(3);
        Instantiate(sun, new Vector2(Random.Range(-9.25f, 6.38f), Random.Range(-2.81f, 4.37f)), Quaternion.identity);
        yield return new WaitForSeconds(15);
        Instantiate(zombie, new Vector2(Random.Range(6.33f, 11.36f), Random.Range(-1.5f, 3f)), Quaternion.identity);
    }
}
