using UnityEngine;

public class TriggerIdentifier : MonoBehaviour
{
    [SerializeField] private Player player;
    private bool _clicked;

    private bool _despawn;

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Sun":
                collision.gameObject.GetComponent<Sun>().Collect();
                break;
            case "Selector" when player.click && !_clicked:
                if (!_despawn)
                {
                    collision.gameObject.GetComponent<Selector>().Spawn();
                }
                else
                {
                    collision.gameObject.GetComponent<Selector>().Despawn();
                    _despawn = false;
                }
                _clicked = true;
                break;
            case "Packet" when player.click && !_clicked:
                collision.gameObject.GetComponent<Packet>().Activate(player.plIndex);
                _clicked = true;
                break;
            case "PacketClose" when player.click && !_clicked:
                collision.gameObject.GetComponent<PacketClose>().Close();
                _clicked = true;
                break;
            case "Despawner" when player.click && !_clicked:
                collision.gameObject.GetComponent<DespawnButton>().Despawn(player.plIndex);
                _despawn = true;
                _clicked = true;
                break;
        }
    }

    public void OnClick()
    {
        _clicked = false;
    }
}
