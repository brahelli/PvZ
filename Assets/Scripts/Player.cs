using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 _cursorPos;
    public bool click;

    private Vector2 _cursorGridSnap;
    private bool _snap;
    private bool _free;

    private float _timeSincePress = 0;

    private PlayerInput _pi;

    [SerializeField] private Transform p1Cursor;
    private Vector3 _moveRef;

    [SerializeField] private CursorChange cursor;
    [SerializeField] private SpriteRenderer trail;

    private Color _cursorColor;
    private float _r, _g, _b;

    private RaycastHit2D _hit;

    public void OnMoveCursor(InputAction.CallbackContext context)
    {
        _cursorPos = context.ReadValue<Vector2>();
        _free = context.performed;
    }

    public void OnCursorClick(InputAction.CallbackContext context)
    {
        click = context.performed;
    }

    public void OnCursorGridSnap(InputAction.CallbackContext context)
    {
        _cursorGridSnap = context.ReadValue<Vector2>();
        _snap = context.performed;
        if (_free)
        {
            p1Cursor.position = new Vector3(-7.8f, 3, 0);
        }
        _free = false;
    }

    private void Start()
    {
        _pi = GetComponent<PlayerInput>();

        _r = Random.Range(25, 100);
        _g = Random.Range(25, 100);
        _b = Random.Range(25, 100);

        _cursorColor = new Color(_r / 100, _g / 100, _b / 100);
        cursor.pi = _pi;
        cursor.color = new Color(_r / 100, _g / 100, _b / 100);
        trail.color = _cursorColor;
    }

    private void Update()
    {
        if (!_snap && _free)
        {
            switch (_pi.currentControlScheme)
            {
                case "Controller":
                    p1Cursor.position += (Vector3)_cursorPos * 0.25f;
                    break;
                case "K&M":
                case "Touch":
                    p1Cursor.position = Camera.main.ScreenToWorldPoint(_cursorPos);
                    p1Cursor.position = new Vector3(p1Cursor.position.x, p1Cursor.position.y, 0);
                    break;
            }
        }
        else if (_timeSincePress <= Time.time && _snap && !_free)
        {
            p1Cursor.position += (Vector3)_cursorGridSnap * 1.2f;
            _timeSincePress = Time.time + 0.1f;
        }

        cursor.joyCapMoveTo = _cursorPos;
    }
}
