using UnityEngine;

public class PlantController : MonoBehaviour
{
    [SerializeField] Vector2[] raycastOrigins;
    [SerializeField] GameObject plantRowOne;
    [SerializeField] GameObject plantRowTwo;
    [SerializeField] GameObject plantRowThree;
    [SerializeField] GameObject plantRowFour;
    [SerializeField] GameObject plantRowFive;

    private void Update()
    {
        CheckForZombies();
    }

    void CheckForZombies()
    {
        for (int i = 0; i < raycastOrigins.Length; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(raycastOrigins[i], Vector2.left);
            if (hit.collider != null && hit.collider.tag == "Zombie")
            {
                switch (i)
                {
                    case 0:
                        plantRowOne.tag = "ZombieDetected";
                        break;
                    case 1:
                        plantRowTwo.tag = "ZombieDetected";
                        break;
                    case 2:
                        plantRowThree.tag = "ZombieDetected";
                        break;
                    case 3:
                        plantRowFour.tag = "ZombieDetected";
                        break;
                    case 4:
                        plantRowFive.tag = "ZombieDetected";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (i)
                {
                    case 0:
                        plantRowOne.tag = "Untagged";
                        break;
                    case 1:
                        plantRowTwo.tag = "Untagged";
                        break;
                    case 2:
                        plantRowThree.tag = "Untagged";
                        break;
                    case 3:
                        plantRowFour.tag = "Untagged";
                        break;
                    case 4:
                        plantRowFive.tag = "Untagged";
                        break;
                    default:
                        break;
                }
            }
        }
    }

    void SpawnPlants(int plantPosH, int plantPosV, string plantType)
    {
        // Plant Row Gameobjects need script that contains all the plants for the row.
        // Each plant is accessible through the plant row gameobjects.

        // This will use the plant row gameobjects to enable the plants at the correct positions, and set the correct type.
    }
}
