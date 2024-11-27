using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTrailBehind : MonoBehaviour
{

    [SerializeField] Transform cursorPos;
    Vector2 refVelocity;

    void Update()
    {
        transform.position = Vector2.SmoothDamp(transform.position, cursorPos.position, ref refVelocity, 0.1f);
    }
}
