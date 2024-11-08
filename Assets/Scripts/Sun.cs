using UnityEngine;

public class Sun : MonoBehaviour
{
    Rigidbody2D rb;

    float yToFall;

    bool collected = false;

    Vector2 collectedMoveTo = new Vector2(10.78f, 7.55f);
    Vector2 otherMoveTo;

    Vector2 collectedRef;
    Vector2 otherRef;
    Vector2 fallRef;

    GameManager gm;

    public bool spawnedBySunflower = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        yToFall = Random.Range(-3.5f, 3f);

        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        otherMoveTo = rb.position + new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
    }

    void Update()
    {
        if (rb.position.y > yToFall && !collected && !spawnedBySunflower)
        {
            transform.position = Vector2.SmoothDamp(rb.position, new Vector2(rb.position.x, yToFall), ref collectedRef, 10f);
        }
        else if (spawnedBySunflower)
        {
            transform.position = Vector2.SmoothDamp(rb.position, otherMoveTo, ref otherRef, .75f);
        }

        if (collected)
        {
            transform.position = Vector2.SmoothDamp(rb.position, collectedMoveTo, ref collectedRef, .75f);
        }
    }

    public void Collect()
    {
        if (!collected)
        {
            gm.sun += 25;
            collected = true;
            Destroy(gameObject, 3f);
        }
    }
}
