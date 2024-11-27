using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 cursorPos;
    public bool click;

    Vector2 cursorGridSnap;
    bool snap;
    bool free;

    float timeSincePress = 0;

    PlayerInput pi;

    [SerializeField] Transform p1Cursor;
    Vector3 moveRef;

    [SerializeField] CursorChange cursor;
    [SerializeField] SpriteRenderer trail;

    Color cursorColor;
    float r, g, b;

    RaycastHit2D hit;

    public void OnMoveCursor(InputAction.CallbackContext context)
    {
        cursorPos = context.ReadValue<Vector2>();
        free = context.performed;
    }

    public void OnCursorClick(InputAction.CallbackContext context)
    {
        click = context.performed;
    }

    public void OnCursorGridSnap(InputAction.CallbackContext context)
    {
        cursorGridSnap = context.ReadValue<Vector2>();
        snap = context.performed;
        if (free)
        {
            p1Cursor.position = new Vector3(-7.8f, 3, 0);
        }
        free = false;
    }

    private void Start()
    {
        pi = GetComponent<PlayerInput>();

        r = Random.Range(25, 100);
        g = Random.Range(25, 100);
        b = Random.Range(25, 100);

        cursorColor = new Color(r / 100, g / 100, b / 100);
        cursor.pi = pi;
        cursor.color = new Color(r / 100, g / 100, b / 100);
        trail.color = cursorColor;
    }

    private void Update()
    {
        if (!snap && free)
        {
            switch (pi.currentControlScheme)
            {
                case "Controller":
                    p1Cursor.position += (Vector3)cursorPos * 0.25f;
                    break;
                case "K&M":
                case "Touch":
                    p1Cursor.position = Camera.main.ScreenToWorldPoint(cursorPos);
                    p1Cursor.position = new Vector3(p1Cursor.position.x, p1Cursor.position.y, 0);
                    break;
            }
        }
        else if (timeSincePress <= Time.time && snap && !free)
        {
            p1Cursor.position += (Vector3)cursorGridSnap * 1.2f;
            timeSincePress = Time.time + 0.1f;
        }

        cursor.joyCapMoveTo = cursorPos;
    }
}
