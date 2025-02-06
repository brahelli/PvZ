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
        
        Destroy(transform.parent.gameObject, .3f);

        Animator anim = transform.parent.GetComponent<Animator>();
        anim.SetTrigger("Close");
    }
}
