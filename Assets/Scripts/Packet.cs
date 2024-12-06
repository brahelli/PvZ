using UnityEngine;

public class Packet : MonoBehaviour
{
    private PlantController _plantController;

    [SerializeField] private string plantType;
    
    //Initialise and assign variables
    
    private void Start()
    {
        _plantController = FindObjectOfType<PlantController>();
        //Find the PlantController object in the scene, might change later, not performant
    }

    public void Activate()
    {
        _plantController.PlantType(plantType);
        //When the user clicks on this packet, begin the process of spawning a plant
    }
}