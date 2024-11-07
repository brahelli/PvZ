using UnityEngine;

public class PlantRow : MonoBehaviour
{
    [SerializeField] Plant[] plants;

    public void Spawn(int plant, string plantType)
    {
        Plant currentPlant = plants[plant];
        currentPlant.gameObject.SetActive(true);

        currentPlant.SetType(plantType);
    }
}
