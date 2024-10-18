using UnityEngine;

public class Selector : MonoBehaviour
{
    public bool plantSpawned = false;
    PlantController plantController;

    [SerializeField] int v;
    [SerializeField] int h;

    Collider2D col;

    string plantType;

    private void Start()
    {
        //gameObject.SetActive(false);
        plantController = GameObject.FindGameObjectWithTag("PlantControl").gameObject.GetComponent<PlantController>();
        col = gameObject.GetComponent<Collider2D>();
    }

    private void Update()
    {
        col.enabled = !plantSpawned;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0f;
            RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector3.forward);
            if (hit && hit.collider.name == "Selector")
            {
                plantController.SpawnPlants(h, v, plantType);
                plantSpawned = true;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(mousePos);
            touchPos.z = 0f;
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.transform.position, touchPos);
            Debug.Log(v.ToString() + "," + h.ToString());
            if (hit == this)
            {
                plantController.SpawnPlants(h, v, plantType);
                plantSpawned = true;
            }
        }
    }

    public void EnableSpawningHere(string plantTypeToSpawn)
    {
        gameObject.SetActive(true);
        plantType = plantTypeToSpawn;
    }

    public void DisableSpawningHere()
    {
        gameObject.SetActive(false);
    }
}
