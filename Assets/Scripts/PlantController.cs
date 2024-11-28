using UnityEngine;

public class PlantController : MonoBehaviour
{
    [SerializeField] private Vector2[] raycastOrigins;
    [SerializeField] private PlantRow plantRowOne;
    [SerializeField] private PlantRow plantRowTwo;
    [SerializeField] private PlantRow plantRowThree;
    [SerializeField] private PlantRow plantRowFour;
    [SerializeField] private PlantRow plantRowFive;

    [SerializeField] private LayerMask zombies;

    [SerializeField] private GameManager gameManager;

    private void Update()
    {
        CheckForZombies();
    }

    private void CheckForZombies()
    {
        for (int i = 0; i < raycastOrigins.Length; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(raycastOrigins[i], Vector2.left, zombies);

            if (hit.collider && hit.collider.CompareTag("Zombie"))
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

    private void StartSpawn(string plantType, int sunCost)
    {
        if (!(gameManager.sun >= sunCost)) return;
        GameObject[] selectors = GameObject.FindGameObjectsWithTag("Selector");

        foreach (var t in selectors)
        {
            Selector selector = t.GetComponent<Selector>();
            selector.EnableSpawningHere(plantType);
        }

        gameManager.sun -= sunCost;
    }

    public void EndSpawn()
    {
        GameObject[] selectors = GameObject.FindGameObjectsWithTag("Selector");

        foreach (var t in selectors)
        {
            Selector selector = t.GetComponent<Selector>();
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
