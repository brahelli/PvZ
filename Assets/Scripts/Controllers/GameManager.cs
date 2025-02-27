using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform[] zombieSpawns;

    public float sun;
    
    [SerializeField] private GameObject[] lanes;

    private PlayerInputManager _pim;

    private int _noOfPlayers;
    
    [SerializeField] private Vector3[] cameraPositions;
    [SerializeField] private float[] cameraSizes;

    [SerializeField] private Camera cam;
    
    private Vector3 _moveRef;
    private float _moveRef2;
    
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
        
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void Start()
    {
        _pim = GetComponent<PlayerInputManager>();

        _noOfPlayers = _pim.playerCount;

    }
    
    public void PlayerJoined()
    {
        _noOfPlayers = _pim.playerCount;
        
        lanes[_noOfPlayers].SetActive(true);
    }
    
    void Update()
    {
        switch (_noOfPlayers)
        {
            case 0:
                cam.transform.position = Vector3.SmoothDamp(cam.transform.position, new Vector3(-22.58f, -16.57f, -10), ref _moveRef, 0.5f);
                cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, 4.28f, ref _moveRef2, 0.5f);
                break;
            case 1:
                cam.transform.position = Vector3.SmoothDamp(cam.transform.position, cameraPositions[0], ref _moveRef, 0.5f);
                cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, cameraSizes[0], ref _moveRef2, 0.5f);
                break;
            case 2:
                cam.transform.position = Vector3.SmoothDamp(cam.transform.position, cameraPositions[1], ref _moveRef, 0.5f);
                cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, cameraSizes[1], ref _moveRef2, 0.5f);
                break;
            case 3:
                cam.transform.position = Vector3.SmoothDamp(cam.transform.position, cameraPositions[2], ref _moveRef, 0.5f);
                cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, cameraSizes[2], ref _moveRef2, 0.5f);
                break;
            case 4:
                cam.transform.position = Vector3.SmoothDamp(cam.transform.position, cameraPositions[3], ref _moveRef, 0.5f);
                cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, cameraSizes[3], ref _moveRef2, 0.5f);
                break;
        }
    }
}
