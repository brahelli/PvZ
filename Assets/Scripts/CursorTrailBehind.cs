using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTrailBehind : MonoBehaviour
{

    [SerializeField] private Transform cursorPos;
    private Vector2 _refVelocity;

    private void Update()
    {
        transform.position = Vector2.SmoothDamp(transform.position, cursorPos.position, ref _refVelocity, 0.1f);
    }
}
