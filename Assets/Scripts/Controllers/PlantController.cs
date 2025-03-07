using UnityEngine;

public class PlantController : MonoBehaviour
{
    [SerializeField] private PlantRow[] plantRows;
    
    [SerializeField] private LayerMask zombies;

    [SerializeField] private GameManager gameManager;

    public int player;
    
    //Initialise and assign variables

    private void StartSpawn(string plantType, int sunCost, int playerS)
    {
        //If the player does not have enough sun, return and do nothing
        if (!(gameManager.sun >= sunCost)) return;
        
        gameManager.sun -= sunCost;

        GameObject[] selectors = GameObject.FindGameObjectsWithTag("Selector");
        foreach (GameObject t in selectors)
        {
            Selector selector = t.GetComponent<Selector>();
            selector.EnableSpawningHere(plantType, playerS);
            //Enable spawning on every selector
        }

    }

    public void StartDespawn(int playerS)
    {
        
        GameObject[] selectors = GameObject.FindGameObjectsWithTag("Selector");
        foreach (GameObject t in selectors)
        {
            Selector selector = t.GetComponent<Selector>();
            selector.EnableSpawningHere("despawn", playerS);
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
        
    }

    public void SpawnPlants(int plantPosH, int plantPosV, string plantType)
    {
        //Depending on the vertical position of the plant, spawn the plant in the correct row
        plantRows[plantPosV].Spawn(plantPosH, plantType);
    }
    
    public void DeSpawnPlants(int plantPosH, int plantPosV)
    {
        //Depending on the vertical position of the plant, spawn the plant in the correct row
        plantRows[plantPosV].Despawn(plantPosH);
    }

    public void PlantType(string plantType, int playerS)
    {
        switch (plantType)
        {
            //Depending on the type of plant, start the spawn process with the correct sun cost
            case "Peashooter":
                StartSpawn(plantType, 100, playerS);
                break;
            case "Sunflower":
                StartSpawn(plantType, 50, playerS);
                break;
            case "Walnut":
                StartSpawn(plantType, 50, playerS);
                break;
        }
    }
}
