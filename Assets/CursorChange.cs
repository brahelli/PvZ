using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorChange : MonoBehaviour
{
    public PlayerInput pi;

    [SerializeField] private SpriteRenderer[] cursors;
    [SerializeField] private Transform joyCap;
    public Vector2 joyCapMoveTo;

    public Color color;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = joyCap.gameObject.GetComponent<SpriteRenderer>();
        foreach (var t in cursors)
        {
            t.color = color;
        }
    }
    
    private void Update()
    {
        switch (pi.currentControlScheme)
        {
            case "Controller":
                cursors[0].enabled = false;
                cursors[1].enabled = false;
                cursors[2].enabled = true;
                _spriteRenderer.enabled = true;

                joyCap.position = joyCapMoveTo / 3;
                break;
            case "K&M":
                cursors[0].enabled = false;
                cursors[1].enabled = true;
                cursors[2].enabled = false;
                _spriteRenderer.enabled = false;
                break;
            case "Touch":
                cursors[0].enabled = true;
                cursors[1].enabled = false;
                cursors[2].enabled = false;
                _spriteRenderer.enabled = false;
                break;
        }
    }
}
