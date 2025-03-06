using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

public class WaveManager : MonoBehaviour
{ 
    
    [SerializeField] private GameObject zombie;
    [SerializeField] private GameObject sun;
    
    [SerializeField] private GameManager gameManager;
    private float _players;

    private float _timeUntilNextSun;

    private float _timeUntilBigWave = 120f;

    private int _bigWavesCompleted = 1;
    
    [SerializeField] private TMP_Text waveText;

    public void StartLevel()
    {
        _timeUntilNextSun = Time.time + Random.Range(10f, 40f);
        
        StartCoroutine(Waves());
    }

    void Update()
    {
        if (_timeUntilNextSun < Time.time)
        {
            Instantiate(sun, new Vector2(Random.Range(-9.25f, 6.38f), Random.Range(-2.81f, 4.37f)), Quaternion.identity);
            _timeUntilNextSun = Time.time + Random.Range(10f, 40f);
        }
        
        waveText.text = "Completed Waves: " + (_bigWavesCompleted - 1).ToString();
    }

    private IEnumerator Waves()
    {
        _players = gameManager.noOfPlayers;
        
        if (_timeUntilBigWave > Time.time)
        {
            Debug.Log("Spawn Normal Wave");
            yield return new WaitForSeconds(Random.Range(20, 30));
            float randomNoZombies = Random.Range(1, 3) * _players;
            for (int i = 0; i < randomNoZombies; i++)
            {
                Instantiate(zombie, new Vector2(Random.Range(6.33f, 11.36f), Random.Range(-1.5f, 3f)), Quaternion.identity);
            }
        }
        else
        {
            Debug.Log("Spawn Big Wave");
            float randomNoZombies = Random.Range(5, 10) * _players * _bigWavesCompleted;
            for (int i = 0; i < randomNoZombies; i++)
            {
                Instantiate(zombie, new Vector2(Random.Range(6.33f, 11.36f), Random.Range(-1.5f, 3f)), Quaternion.identity);
            }
            _bigWavesCompleted++;
            _timeUntilBigWave = Time.time + 120f;
        }
        
        StartCoroutine(Waves());
    }
}
