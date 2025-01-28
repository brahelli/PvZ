using UnityEngine;

public class Packet : MonoBehaviour
{
    private PlantController[] _plantControllers;

    [SerializeField] private string plantType;
    
    //Initialise and assign variables

    private void Start()
    {
        _plantControllers = FindObjectsOfType<PlantController>();
    }

    public void Activate()
    {
        _plantControllers[0].PlantType(plantType);
        //When the user clicks on this packet, begin the process of spawning a plant
        Destroy(transform.parent.gameObject);
    }
}