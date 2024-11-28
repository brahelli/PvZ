using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Packet : MonoBehaviour
{
    private PlantController _plantController;

    [SerializeField] private string plantType;
    
    private void Start()
    {
        _plantController = FindObjectOfType<PlantController>();
    }

    public void Activate()
    {
        Debug.Log("Packet activated");
        _plantController.PlantType(plantType);
    }
}