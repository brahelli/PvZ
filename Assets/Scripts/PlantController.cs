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
    
    bool _isSpawning;
    
    //Initialise and assign variables

    private void Update()
    {
        CheckForZombies();
        //Check for zombies in the raycast origins
    }

    private void CheckForZombies()
    {
        for (int i = 0; i < raycastOrigins.Length; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(raycastOrigins[i], Vector2.left, zombies);
            //For every raycast origin, check if there is a zombie in the way

            if (hit.collider && hit.collider.CompareTag("Zombie"))
            {
                //If there is a zombie in the way, set the tag of the plant row to ZombieDetected
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
                }
            }
            else
            {
                //If there is no zombie in the way, set the tag of the plant row to Untagged
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
                }
            }
        }
    }

    private void StartSpawn(string plantType, int sunCost)
    {
        //If the player does not have enough sun, return and do nothing
        if (!(gameManager.sun >= sunCost)) return;
        
        if (!_isSpawning)
        {
            gameManager.sun -= sunCost;
            //Subtract the cost of the plant from the player's sun if the player is not trying to spawn a plant already
        }
        
        _isSpawning = true;
        //Set the isSpawning variable to true

        GameObject[] selectors = GameObject.FindGameObjectsWithTag("Selector");
        foreach (var t in selectors)
        {
            Selector selector = t.GetComponent<Selector>();
            selector.EnableSpawningHere(plantType);
            //Enable spawning on every selector
        }

    }

    public void EndSpawn()
    {
        GameObject[] selectors = GameObject.FindGameObjectsWithTag("Selector");
        foreach (var t in selectors)
        {
            Selector selector = t.GetComponent<Selector>();
            selector.DisableSpawningHere();
            //Disable spawning on every selector
        }
        
        _isSpawning = false;
        //Set the isSpawning variable to false
    }

    public void SpawnPlants(int plantPosH, int plantPosV, string plantType)
    {
        //Depending on the vertical position of the plant, spawn the plant in the correct row
        switch (plantPosV)
        {
            case 0:
                plantRowOne.Spawn(plantPosH, plantType);
                //Spawn the plant in the first row with the correct type of plant
                break;
            case 1:
                plantRowTwo.Spawn(plantPosH, plantType);
                //Spawn the plant in the second row with the correct type of plant
                break;
            case 2:
                plantRowThree.Spawn(plantPosH, plantType);
                //Spawn the plant in the third row with the correct type of plant
                break;
            case 3:
                plantRowFour.Spawn(plantPosH, plantType);
                //Spawn the plant in the fourth row with the correct type of plant
                break;
            case 4:
                plantRowFive.Spawn(plantPosH, plantType);
                //Spawn the plant in the fifth row with the correct type of plant
                break;
        }
    }

    public void PlantType(string plantType)
    {
        switch (plantType)
        {
            //Depending on the type of plant, start the spawn process with the correct sun cost
            case "Peashooter":
                StartSpawn(plantType, 100);
                break;
            case "Sunflower":
                StartSpawn(plantType, 25);
                break;
        }
    }
}
