using UnityEngine;

public class PlantController : MonoBehaviour
{
    [SerializeField] Vector2[] raycastOrigins;
    [SerializeField] PlantRow plantRowOne;
    [SerializeField] PlantRow plantRowTwo;
    [SerializeField] PlantRow plantRowThree;
    [SerializeField] PlantRow plantRowFour;
    [SerializeField] PlantRow plantRowFive;

    [SerializeField] LayerMask zombies;

    [SerializeField] GameManager gameManager;

    private void Update()
    {
        CheckForZombies();
    }

    void CheckForZombies()
    {
        for (int i = 0; i < raycastOrigins.Length; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(raycastOrigins[i], Vector2.left, zombies);

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

    public void StartSpawn(string plantType, int sunCost)
    {
        if (gameManager.sun >= sunCost)
        {
            GameObject[] selectors = GameObject.FindGameObjectsWithTag("Selector");

            for (int i = 0; i < selectors.Length; i++)
            {
                Selector selector = selectors[i].GetComponent<Selector>();
                selector.EnableSpawningHere(plantType);
            }

            gameManager.sun -= sunCost;
        }
    }

    public void EndSpawn()
    {
        GameObject[] selectors = GameObject.FindGameObjectsWithTag("Selector");

        for (int i = 0; i < selectors.Length; i++)
        {
            Selector selector = selectors[i].GetComponent<Selector>();
            selector.DisableSpawningHere();
        }
    }

    public void SpawnPlants(int plantPosH, int plantPosV, string plantType)
    {
        switch (plantPosV)
        {
            case 0:
                plantRowOne.Spawn(plantPosH, plantType);
                break;
            case 1:
                plantRowTwo.Spawn(plantPosH, plantType);
                break;
            case 2:
                plantRowThree.Spawn(plantPosH, plantType);
                break;
            case 3:
                plantRowFour.Spawn(plantPosH, plantType);
                break;
            case 4:
                plantRowFive.Spawn(plantPosH, plantType);
                break;
            default: break;
        }
    }

    public void PlantType(string plantType)
    {
        switch (plantType)
        {
            case "Peashooter":
                StartSpawn(plantType, 100);
                break;
            case "Sunflower":
                StartSpawn(plantType, 25);
                break;
        }
    }
}
