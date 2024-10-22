using System;
using System.Collections;
// ^ for coroutines
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform[] zombieSpawns;

    [SerializeField] TMP_Text sunDisp;

    public float sun = 0;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        sunDisp.text = "Sun: " + sun.ToString();

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0f;
            RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector3.forward);
            HitDetector(hit);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(mousePos);
            touchPos.z = 0f;
            RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector3.forward);
            HitDetector(hit);
        }
    }

    void HitDetector(RaycastHit2D hit)
    {
        if (hit && hit.collider.name == "Selector")
        {
            Selector selector = hit.transform.gameObject.GetComponent<Selector>();
            selector.Spawn();
        }
        else if (hit.collider.tag == "Sun")
        {
            Sun sun = hit.transform.gameObject.GetComponent<Sun>();
            sun.Collect();
        }
        else
        {
            return;
        }
    }
}
