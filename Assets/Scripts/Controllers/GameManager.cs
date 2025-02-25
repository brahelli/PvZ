using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform[] zombieSpawns;

    public float sun;
    
    [SerializeField] private GameObject[] lanes;

    private PlayerInputManager _pim;

    private int _noOfPlayers;
    
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
    
    private void Start()
    {
        _pim = GetComponent<PlayerInputManager>();

        _noOfPlayers = _pim.playerCount;

    }
    
    public void PlayerJoined()
    {
        lanes[_noOfPlayers].SetActive(true);
    }
}
