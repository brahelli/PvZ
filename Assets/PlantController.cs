using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlantController : MonoBehaviour
{
    [SerializeField] Vector2[] raycastOrigins;
    [SerializeField] GameObject plantRowOne;
    [SerializeField] GameObject plantRowTwo;
    [SerializeField] GameObject plantRowThree;
    [SerializeField] GameObject plantRowFour;
    [SerializeField] GameObject plantRowFive;

    private void Update()
    {
        for (int i = 0; i < raycastOrigins.Length; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(raycastOrigins[i], Vector2.left);
            if(hit.collider != null && hit.collider.tag == "Zombie")
            {
                switch (i)
                {
                    case 0:
                        plantRowOne.tag = "ZombieDetected";
                        break;
                    case 1:
                        plantRowTwo.tag = "ZombieDetected";
                        break;
                    case 2:
                        plantRowThree.tag = "ZombieDetected";
                        break;
                    case 3:
                        plantRowFour.tag = "ZombieDetected";
                        break;
                    case 4:
                        plantRowFive.tag = "ZombieDetected";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (i)
                {
                    case 0:
                        plantRowOne.tag = "Untagged";
                        break;
                    case 1:
                        plantRowTwo.tag = "Untagged";
                        break;
                    case 2:
                        plantRowThree.tag = "Untagged";
                        break;
                    case 3:
                        plantRowFour.tag = "Untagged";
                        break;
                    case 4:
                        plantRowFive.tag = "Untagged";
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
