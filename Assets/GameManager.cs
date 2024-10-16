using System;
using System.Collections;
// ^ for coroutines
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform[] zombieSpawns;

    [SerializeField] TMP_Text sunDisp;

    public float sun = 0;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        sunDisp.text = "Sun: " + sun.ToString();
    }
}
