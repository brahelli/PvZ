using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerIdentifier : MonoBehaviour
{
    [SerializeField] Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.tag == "Sun")
        {
            collision.gameObject.GetComponent<Sun>().Collect();
        }
        else if(collision.tag == "Selector" && player.click)
        {
            collision.gameObject.GetComponent<Selector>().Spawn();
        }
    }
}
