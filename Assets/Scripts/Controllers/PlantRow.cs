using System;
using UnityEngine;

public class PlantRow : MonoBehaviour
{
    [SerializeField] private Plant[] plants;
    // ^ an array of Plant objects
    
    [SerializeField] public PlantController plantController;
    // ^ a reference to the PlantController object for Selector objects to access

    public void Spawn(int plant, string plantType)
    {
        Plant currentPlant = plants[plant];
        currentPlant.gameObject.SetActive(true);
        //Activate the plant at the specified position

        currentPlant.SetType(plantType);
        //Set the plant to the right type
    }
    
    public void Despawn(int plant)
    {
        Plant currentPlant = plants[plant];
        currentPlant.gameObject.SetActive(false);
        //Deactivate the plant at the specified position
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            gameObject.tag = "ZombieDetected";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            gameObject.tag = "Untagged";
        }
    }
}
