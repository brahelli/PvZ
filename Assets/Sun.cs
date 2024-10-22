using UnityEngine;

public class Sun : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float fallSpeed = 1f;

    float yToFall;

    bool collected = false;

    Vector2 collectedMoveTo = new Vector2(10.78f, 7.55f);
    Vector2 collectedRef;

    GameManager gm;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.position = new Vector2(rb.position.x, 7f);

        yToFall = Random.Range(-3.5f, 3f);

        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (rb.position.y > yToFall && !collected)
        {
            Fall();
        }
        else if (collected)
        {
            //rb.MovePosition(rb.position + collectedMoveTo * fallSpeed * Time.deltaTime);

            transform.position = Vector2.SmoothDamp(rb.position, collectedMoveTo, ref collectedRef, .75f);
        }
    }

    void Fall()
    {
        rb.MovePosition(rb.position + Vector2.down * fallSpeed * Time.deltaTime);
    }

    public void Collect()
    {
        gm.sun += 25;
        collected = true;
        Destroy(gameObject, 3f);
    }
}
