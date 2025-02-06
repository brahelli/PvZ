using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnButton : MonoBehaviour
{
    private PlantController[] _plantControllers;
    
    private void Start()
    {
        _plantControllers = FindObjectsOfType<PlantController>();
    }
    
    public void Despawn(int player)
    {
        _plantControllers[player].StartDespawn(player);
    }
}
