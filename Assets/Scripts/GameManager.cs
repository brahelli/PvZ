using System;
using System.Collections;
// ^ for coroutines
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform[] zombieSpawns;

    [SerializeField] private TMP_Text sunDisp;

    public float sun = 0;
    
    //Initialise and assign variables

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        //Disable vSync in order to then fix the framerate to 60fps.
        //I did this in order to keep the game running at a consistent speed,
        //as the framerate was fluctuating too much and causing the game to stutter
        
        Cursor.visible = false;
        //Hide the cursor
    }

    private void Update()
    {
        sunDisp.text = "Sun: " + sun;
        //Update the sun display text to show the current amount of sun to the user
    }
}
