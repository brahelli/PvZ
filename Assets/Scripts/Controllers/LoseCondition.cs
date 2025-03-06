using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour
{

    [SerializeField] private GameObject gameOverScreen;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            gameOverScreen.SetActive(true);
            StartCoroutine(nameof(End));
        }
    }

    private IEnumerator End()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Level1");
    }
}
