using UnityEngine;

public class PlantRow : MonoBehaviour
{
    [SerializeField] private Plant[] plants;
    // ^ an array of Plant objects

    public void Spawn(int plant, string plantType)
    {
        Plant currentPlant = plants[plant];
        currentPlant.gameObject.SetActive(true);
        //Activate the plant at the specified position

        currentPlant.SetType(plantType);
        //Set the plant to the right type
    }
}
