using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Sun : MonoBehaviour
{
    private static readonly int Despawn = Animator.StringToHash("Despawn");
    private Rigidbody2D _rb;

    private bool _collected;
    private Vector2 _refCollectedScale;
    private Vector2 _refCollectedScaleSparks;
    private Vector2 _refCollectedScaleTrail;
    private float _refCollectedIntensitySunLight;

    private Vector2 _otherMoveTo;

    private Vector2 _collectedRef;
    private Vector2 _otherRef;
    private Vector2 _fallRef;

    private GameManager _gm;

    public bool spawnedBySunflower;

    [SerializeField] private GameObject collectExplode;
    [SerializeField] private Transform sparks;
    [SerializeField] private Transform trail;
    [SerializeField] private Light2D sunLight;

    private Animator _anim;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        _otherMoveTo = _rb.position + new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));

        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (spawnedBySunflower && !_collected)
        {
            transform.position = Vector2.SmoothDamp(_rb.position, _otherMoveTo, ref _otherRef, .75f);
        }

        if (_collected)
        {
            sunLight.intensity = Mathf.SmoothDamp(sunLight.intensity, 0, ref _refCollectedIntensitySunLight, .3f);
        }
    }

    public void Collect()
    {
        if (_collected) return;
        _gm.sun += 25;
        _collected = true;
        Instantiate(collectExplode, transform.position, Quaternion.identity);
        _anim.SetTrigger(Despawn);
        Destroy(gameObject, 5f);
    }
}
