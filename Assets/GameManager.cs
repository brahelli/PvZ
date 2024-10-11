using System;
using System.Collections;
// ^ for coroutines
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform[] zombieSpawns;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
}
