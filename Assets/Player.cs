using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 cursorPos;
    bool click;

    Vector2 cursorGridSnap;
    bool snap;
    bool free;

    float timeSincePress = 0;

    PlayerInput pi;

    [SerializeField] Transform p1Cursor;

    [SerializeField] SpriteRenderer cursor;
    [SerializeField] SpriteRenderer trail;

    Color cursorColor;
    float r, g, b;

    RaycastHit2D hit;
    public LayerMask hitArea;

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

        r = Random.Range(0, 100);
        g = Random.Range(0, 100);
        b = Random.Range(0, 100);

        cursorColor = new Color(r / 100,g / 100,b / 100);
        cursor.color = cursorColor;
        trail.color = cursorColor;
    }

    private void Update()
    {
        if(!snap && free)
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
        }
        else if(timeSincePress <= Time.time && snap && !free)
        {
            p1Cursor.position += new Vector3(cursorGridSnap.x, 0, 0) * 1.2f;
            p1Cursor.position += new Vector3(0, cursorGridSnap.y, 0) * 1.2f;
            timeSincePress = Time.time + 0.1f;
        }

        Debug.Log(free);

        if (click)
        {
            TouchScreen(cursorPos);
        }

        Debug.Log(timeSincePress.ToString() + " : " + Time.time.ToString());
    }

    void TouchScreen(Vector2 touchPosScreen)
    {
        hit = Physics2D.Raycast(p1Cursor.position, Vector3.forward, hitArea);
        HitDetector(hit);
    }

    void HitDetector(RaycastHit2D hit)
    {
        if (hit && hit.collider.name == "Selector")
        {
            Selector selector = hit.transform.gameObject.GetComponent<Selector>();
            selector.Spawn();
        }
        /*else if (hit && hit.collider.tag == "Sun")
        {
            Sun sun = hit.transform.gameObject.GetComponent<Sun>();
            sun.Collect();
        }*/
        else
        {
            return;
        }
    }
}
