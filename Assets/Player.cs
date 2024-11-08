using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 cursorPos;
    bool click;

    PlayerInput pi;

    [SerializeField] Transform p1Cursor;

    [SerializeField] SpriteRenderer cursor;
    [SerializeField] SpriteRenderer trail;

    Color cursorColor;
    float r, g, b;

    RaycastHit2D hit;

    public void OnMoveCursor(InputAction.CallbackContext context)
    {
        cursorPos = context.ReadValue<Vector2>();
    }

    public void OnCursorClick(InputAction.CallbackContext context)
    {
        click = context.performed;
    }

    private void Start()
    {
        pi = GetComponent<PlayerInput>();

        r = Random.Range(0, 100);
        g = Random.Range(0, 100);
        b = Random.Range(0, 100);

        cursorColor = new Color(r / 100,g / 100,b / 100);
        cursor.color = cursorColor;
        trail.color = cursorColor;
    }

    private void Update()
    {
        switch (pi.currentControlScheme)
        {
            case "Controller":
                p1Cursor.position += new Vector3(cursorPos.x, cursorPos.y, 0f);
                break;
            case "K&M":
                p1Cursor.position = Camera.main.ScreenToWorldPoint(cursorPos);
                p1Cursor.position = new Vector3(p1Cursor.position.x, p1Cursor.position.y, 0);
                break;
            case "Touch":
                p1Cursor.position = Camera.main.ScreenToWorldPoint(cursorPos);
                p1Cursor.position = new Vector3(p1Cursor.position.x, p1Cursor.position.y, 0);
                break;
        }

        if (click)
        {
            TouchScreen(cursorPos);
        }
    }

    void TouchScreen(Vector2 touchPosScreen)
    {
        Vector3 touchPos = Camera.main.ScreenToWorldPoint(touchPosScreen);
        touchPos.z = 0f;
        hit = Physics2D.Raycast(touchPos, Vector3.forward);
        HitDetector(hit);
    }

    void HitDetector(RaycastHit2D hit)
    {
        if (hit && hit.collider.name == "Selector")
        {
            Selector selector = hit.transform.gameObject.GetComponent<Selector>();
            selector.Spawn();
        }
        else if (hit && hit.collider.tag == "Sun")
        {
            Sun sun = hit.transform.gameObject.GetComponent<Sun>();
            sun.Collect();
        }
        else
        {
            return;
        }
    }
}
