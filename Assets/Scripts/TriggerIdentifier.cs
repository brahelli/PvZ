using UnityEngine;

public class TriggerIdentifier : MonoBehaviour
{
    [SerializeField] private Player player;
    private bool _clicked;

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Sun":
                collision.gameObject.GetComponent<Sun>().Collect();
                break;
            case "Selector" when player.click && !_clicked:
                collision.gameObject.GetComponent<Selector>().Spawn();
                _clicked = true;
                break;
            case "Packet" when player.click && !_clicked:
                collision.gameObject.GetComponent<Packet>().Activate();
                _clicked = true;
                break;
        }
    }

    public void OnClick()
    {
        _clicked = false;
    }
}
