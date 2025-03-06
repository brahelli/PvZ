using UnityEngine;

public class Packet : MonoBehaviour
{
    private static readonly int Close = Animator.StringToHash("Close");
    private PlantController[] _plantControllers;
    private PassThroughToPacket _passThroughToPacket;

    [SerializeField] private string plantType;
    
    //Initialise and assign variables

    private void Start()
    {
        _plantControllers = FindObjectsOfType<PlantController>();
        _passThroughToPacket = GetComponentInParent<PassThroughToPacket>();
    }

    public void Activate(int player)
    {
        _plantControllers[player].PlantType(plantType, player);
        //When the user clicks on this packet, begin the process of spawning a plant

        _passThroughToPacket.player.packetsSpawned = false;
        
        Destroy(transform.parent.gameObject, .3f);

        Animator anim = transform.parent.GetComponent<Animator>();
        anim.SetTrigger(Close);
    }
}