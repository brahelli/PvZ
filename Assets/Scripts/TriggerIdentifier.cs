using UnityEngine;

public class TriggerIdentifier : MonoBehaviour
{
    [SerializeField] private Player player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Sun":
                collision.gameObject.GetComponent<Sun>().Collect();
                break;
            case "Selector" when player.click:
                collision.gameObject.GetComponent<Selector>().Spawn();
                break;
            case "Packet" when player.click:
                collision.gameObject.GetComponent<Packet>().Activate();
                break;
        }
    }
}
