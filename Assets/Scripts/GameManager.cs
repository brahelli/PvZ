using System;
using System.Collections;
// ^ for coroutines
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform[] zombieSpawns;

    [SerializeField] TMP_Text sunDisp;

    Vector2 cursorPos;
    bool click;

    PlayerInput pi;

    [SerializeField] Transform p1Cursor;
    [SerializeField] Transform p2Cursor;

    public float sun = 0;

    public void OnMoveCursor(InputAction.CallbackContext context)
    {
        cursorPos = context.ReadValue<Vector2>();
    }

    public void OnCursorClick(InputAction.CallbackContext context)
    {
        click = context.performed;
    }

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        Cursor.visible = false;

        pi = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        sunDisp.text = "Sun: " + sun.ToString();

        /*if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            TouchScreen(touch.position);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            TouchScreen(mousePos);
        }*/

        switch (pi.currentControlScheme)
        {
            case "Controller":
                p1Cursor.position += new Vector3(cursorPos.x, cursorPos.y, 0f);
                p1Cursor.GetComponent<SpriteRenderer>().color = new Color(0, 251, 255, 255);
                break;
            case "KM":
                p1Cursor.position = Camera.main.ScreenToWorldPoint(cursorPos);
                p1Cursor.position = new Vector3(p1Cursor.position.x, p1Cursor.position.y, 0);
                p1Cursor.GetComponent<SpriteRenderer>().color = new Color(0, 251, 255, 255);
                break;
            case "Touch":
                p1Cursor.GetComponent<SpriteRenderer>().color = new Color(0, 251, 255, 100);
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
        RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector3.forward);
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
