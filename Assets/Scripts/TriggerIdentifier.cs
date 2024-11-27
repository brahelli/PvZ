using UnityEngine;

public class TriggerIdentifier : MonoBehaviour
{
    [SerializeField] Player player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(player.click);
        Debug.Log(collision.name);
        if (collision.tag == "Sun")
        {
            collision.gameObject.GetComponent<Sun>().Collect();
        }
        else if (collision.tag == "Selector" && player.click)
        {
            collision.gameObject.GetComponent<Selector>().Spawn();
        }
    }
}
