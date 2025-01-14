using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Sun : MonoBehaviour
{
    private Rigidbody2D _rb;

    private float _yToFall;

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

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _yToFall = Random.Range(-3.5f, 3f);

        _gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        _otherMoveTo = _rb.position + new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
    }

    private void Update()
    {
        if (_rb.position.y > _yToFall && !_collected && !spawnedBySunflower)
        {
            transform.position = Vector2.SmoothDamp(_rb.position, new Vector2(_rb.position.x, _yToFall), ref _collectedRef, 10f);
        }
        else if (spawnedBySunflower)
        {
            transform.position = Vector2.SmoothDamp(_rb.position, _otherMoveTo, ref _otherRef, .75f);
        }

        if (_collected)
        {
            transform.localScale = Vector2.SmoothDamp(transform.localScale, Vector2.zero, ref _refCollectedScale, .3f);
            sparks.localScale = Vector2.SmoothDamp(sparks.transform.localScale, Vector2.zero, ref _refCollectedScaleSparks, .3f);
            trail.localScale = Vector2.SmoothDamp(trail.transform.localScale, Vector2.zero, ref _refCollectedScaleTrail, .3f);
            sunLight.intensity = Mathf.SmoothDamp(sunLight.intensity, 0, ref _refCollectedIntensitySunLight, .3f);
        }
    }

    public void Collect()
    {
        if (_collected) return;
        _gm.sun += 25;
        _collected = true;
        Instantiate(collectExplode, transform.position, Quaternion.identity);
        Destroy(gameObject, 5f);
    }
}
