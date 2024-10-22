using UnityEngine;

public class Selector : MonoBehaviour
{
    public bool plantSpawned = false;
    PlantController plantController;

    SpriteRenderer spriteRenderer;

    [SerializeField] int v;
    [SerializeField] int h;

    BoxCollider2D col;

    string plantType;

    private void Start()
    {
        plantController = GameObject.FindGameObjectWithTag("PlantControl").gameObject.GetComponent<PlantController>();
        col = gameObject.GetComponent<BoxCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Spawn()
    {
        plantController.SpawnPlants(h, v, plantType);
        plantController.EndSpawn();
        plantSpawned = true;
    }

    public void EnableSpawningHere(string plantTypeToSpawn)
    {
        if (!plantSpawned)
        {
            col.enabled = true;
            spriteRenderer.enabled = true;
            plantType = plantTypeToSpawn;
        }
    }

    public void DisableSpawningHere()
    {
        col.enabled = false;
        spriteRenderer.enabled = false;
        plantType = null;
    }
}
