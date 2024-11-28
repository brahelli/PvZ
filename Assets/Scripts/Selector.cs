using UnityEngine;
using UnityEngine.EventSystems;

public class Selector : MonoBehaviour
{
    public bool plantSpawned = false;
    private PlantController _plantController;

    private SpriteRenderer _spriteRenderer;

    [SerializeField] private int v;
    [SerializeField] private int h;

    private BoxCollider2D _col;

    private string _plantType;

    private void Start()
    {
        _plantController = GameObject.FindGameObjectWithTag("PlantControl").gameObject.GetComponent<PlantController>();
        _col = gameObject.GetComponent<BoxCollider2D>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Spawn()
    {
        _plantController.SpawnPlants(h, v, _plantType);
        _plantController.EndSpawn();
        plantSpawned = true;
    }

    public void EnableSpawningHere(string plantTypeToSpawn)
    {
        if (!plantSpawned)
        {
            _col.enabled = true;
            _spriteRenderer.enabled = true;
            _plantType = plantTypeToSpawn;
        }
    }

    public void DisableSpawningHere()
    {
        _col.enabled = false;
        _spriteRenderer.enabled = false;
        _plantType = null;
    }
}
