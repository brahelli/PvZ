using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacketClose : MonoBehaviour
{
    public void Close()
    {
        Destroy(transform.parent.gameObject, .3f);
        
        Animator anim = transform.parent.GetComponent<Animator>();
        anim.SetTrigger("Close");
    }
}
