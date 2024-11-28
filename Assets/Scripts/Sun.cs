using UnityEngine;

public class Sun : MonoBehaviour
{
    private Rigidbody2D _rb;

    private float _yToFall;

    private bool _collected = false;

    private readonly Vector2 _collectedMoveTo = new Vector2(10.78f, 7.55f);
    private Vector2 _otherMoveTo;

    private Vector2 _collectedRef;
    private Vector2 _otherRef;
    private Vector2 _fallRef;

    private GameManager _gm;

    public bool spawnedBySunflower = false;

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
            transform.position = Vector2.SmoothDamp(_rb.position, _collectedMoveTo, ref _collectedRef, .75f);
        }
    }

    public void Collect()
    {
        if (!_collected)
        {
            _gm.sun += 25;
            _collected = true;
            Destroy(gameObject, 3f);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Collect();
        }
    }*/
}
