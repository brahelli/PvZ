using UnityEngine;

public class PacketClose : MonoBehaviour
{
    private static readonly int Close1 = Animator.StringToHash("Close");
    private PassThroughToPacket _passThroughToPacket;
    
    private void Start()
    {
        _passThroughToPacket = GetComponentInParent<PassThroughToPacket>();
    }
    
    public void Close()
    {
        _passThroughToPacket.player.packetsSpawned = false;
        
        Destroy(transform.parent.gameObject, .3f);
        
        Animator anim = transform.parent.GetComponent<Animator>();
        anim.SetTrigger(Close1);
    }
}
