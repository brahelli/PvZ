using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float fallSpeed = 1f;

    float yToFall;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.position = new Vector2(rb.position.x, 7f);

        yToFall = Random.Range(-3.5f, 3f);

        Destroy(gameObject, 15f);
    }

    void Update()
    {
        if(rb.position.y > yToFall)
        {
            Fall();
        }

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0f;
            RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector3.forward);
            if (hit.collider.name == "Sun")
            {
                Collect();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(mousePos);
            touchPos.z = 0f;
            RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector3.forward);
            if(hit.collider.name == "Sun")
            {
                Collect();
            }
        }
    }

    void Fall()
    {
        rb.MovePosition(rb.position + Vector2.down * fallSpeed * Time.deltaTime);
    }

    void Collect()
    {
        Destroy(gameObject);
    }
}
