using UnityEngine;

public class TriggerIdentifier : MonoBehaviour
{
    [SerializeField] private Player player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(player.click);
        Debug.Log(collision.name);
        switch (collision.tag)
        {
            case "Sun":
                collision.gameObject.GetComponent<Sun>().Collect();
                break;
            case "Selector" when player.click:
                collision.gameObject.GetComponent<Selector>().Spawn();
                break;
        }
    }
}
