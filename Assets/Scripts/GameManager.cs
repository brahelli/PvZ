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

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        Cursor.visible = false;
    }

    private void Update()
    {
        sunDisp.text = "Sun: " + sun;
    }
}
