using UnityEngine;

public class LoseCondition : MonoBehaviour
{

    [SerializeField] private GameObject gameOverScreen;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            gameOverScreen.SetActive(true);
        }
    }
}
