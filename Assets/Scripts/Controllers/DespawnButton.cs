using UnityEngine;

public class DespawnButton : MonoBehaviour
{
    private PlantController[] _plantControllers;
    private PassThroughToPacket _passThroughToPacket;
    
    private void Start()
    {
        _plantControllers = FindObjectsOfType<PlantController>();
        _passThroughToPacket = GetComponentInParent<PassThroughToPacket>();
    }
    
    public void Despawn(int player)
    {
        _plantControllers[player].StartDespawn(player);
        
        _passThroughToPacket.player.packetsSpawned = false;
        
        Destroy(transform.parent.gameObject, .3f);

        Animator anim = transform.parent.GetComponent<Animator>();
        anim.SetTrigger("Close");
    }
}
