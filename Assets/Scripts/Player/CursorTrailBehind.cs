using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTrailBehind : MonoBehaviour
{

    [SerializeField] private Transform cursorPos;
    private Vector2 _refVelocity;
    
    //Initialise and assign variables

    private void Update()
    {
        transform.position = Vector2.SmoothDamp(transform.position, cursorPos.position, ref _refVelocity, 0.1f);
        //Smoothly move the object to the cursor position with damping over 0.1 seconds
    }
}
