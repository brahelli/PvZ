using UnityEngine;
using TMPro;

public class UpdateText : MonoBehaviour
{
    
    private GameManager _gameManager;
    
    private TMP_Text _sunDisp;
    
    void Start()
    {
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        _sunDisp = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _sunDisp.text = "" + _gameManager.sun;
    }
}
