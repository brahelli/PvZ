using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    private Vector2 _cursorPos;
    public bool click;

    private Vector2 _cursorGridSnap;
    private bool _snap;
    private bool _free;

    private float _timeSincePress;

    private PlayerInput _pi;

    [SerializeField] private Transform p1Cursor;
    private Vector3 _moveRef;

    [SerializeField] private CursorChange cursor;
    [SerializeField] private SpriteRenderer trail;

    private Color _cursorColor;
    private float _r, _g, _b;

    private RaycastHit2D _hit;

    [SerializeField] private GameObject packets;
    
    //Initialise and assign variables

    public void OnMoveCursor(InputAction.CallbackContext context)
    {
        _cursorPos = context.ReadValue<Vector2>();
        _free = context.performed;
        //If the player is moving the cursor, set the cursor position to the value of the movement vector and set free to true
    }

    public void OnCursorClick(InputAction.CallbackContext context)
    {
        click = context.performed;
        //If the player clicks, set click to true
    }

    public void OnCursorGridSnap(InputAction.CallbackContext context)
    {
        _cursorGridSnap = context.ReadValue<Vector2>();
        _snap = context.performed;
        //If the player is snapping the cursor to the grid, set the cursor grid snap to the value of the movement vector and set snap to true
        if (_free)
        {
            p1Cursor.position = new Vector3(-7.8f, 3, 0);
            //If the movement was previously free, snap the cursor to the top left selector
        }
        _free = false;
        //Set free to false
    }

    public void OnNewPlant(InputAction.CallbackContext context)
    {
        Instantiate(packets, transform.position, quaternion.identity);
    }

    private void Start()
    {
        _pi = GetComponent<PlayerInput>();
        //Get the PlayerInput component from this object

        _r = Random.Range(25, 100);
        _g = Random.Range(25, 100);
        _b = Random.Range(25, 100);
        //Generate random values for the RGB color of the cursor

        _cursorColor = new Color(_r / 100, _g / 100, _b / 100);
        cursor.color = new Color(_r / 100, _g / 100, _b / 100);
        trail.color = _cursorColor;
        //Set the cursor color to the generated RGB values and set the trail color to the cursor color
        
        cursor.pi = _pi;
        //Set the PlayerInput component of the cursor to this object's PlayerInput component
        
    }

    private void Update()
    {
        if (!_snap && _free)
        {
            //If the cursor is not snapping to the grid and is free to move
            switch (_pi.currentControlScheme)
            {
                //Depending on the device the player is using, move the cursor to the appropriate position
                case "Controller":
                    p1Cursor.position += (Vector3)_cursorPos * 0.25f;
                    //Move the cursor by the movement vector multiplied by 0.25
                    break;
                case "K&M":
                case "Touch":
                    p1Cursor.position = Camera.main.ScreenToWorldPoint(_cursorPos);
                    p1Cursor.position = new Vector3(p1Cursor.position.x, p1Cursor.position.y, 0);
                    //Get the position of where the user touched the screen, change it to world space, and move the cursor to that position
                    break;
            }
        }
        else if (_timeSincePress <= Time.time && _snap && !_free)
        {
            //If the cursor is snapping to the grid and is not free to move, and the time since the last press is less than the current time
            p1Cursor.position += (Vector3)_cursorGridSnap * 1.2f;
            //Move the cursor by the grid snap vector multiplied by 1.2
            _timeSincePress = Time.time + 0.1f;
            //Generate a new time since the last press
        }

        cursor.joyCapMoveTo = _cursorPos;
        //Set the joystick cursor's movement to the cursor position
    }
}
