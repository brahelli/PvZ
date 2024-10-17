using UnityEngine;

public class PlantRow : MonoBehaviour
{
    [SerializeField] Plant[] plants;

    public void Spawn(int plant, string plantType)
    {
        plants[plant].gameObject.SetActive(true);
    }
}
