using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlantController : MonoBehaviour
{
    [SerializeField] Vector2[] raycastOrigins;
    [SerializeField] Plant[] plantRowOne;
    [SerializeField] Plant[] plantRowTwo;
    [SerializeField] Plant[] plantRowThree;
    [SerializeField] Plant[] plantRowFour;
    [SerializeField] Plant[] plantRowFive;

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
                        for (int j = 0; j < plantRowOne.Length; j++)
                        {
                            plantRowOne[j].gameObject.GetComponent<Plant>().detectEnemy = true;
                        }
                        break;
                    case 1:
                        for (int j = 0; j < plantRowTwo.Length; j++)
                        {
                            plantRowTwo[j].gameObject.GetComponent<Plant>().detectEnemy = true;
                        }
                        break;
                    case 2:
                        for (int j = 0; j < plantRowThree.Length; j++)
                        {
                            plantRowThree[j].gameObject.GetComponent<Plant>().detectEnemy = true;
                        }
                        break;
                    case 3:
                        for (int j = 0; j < plantRowFour.Length; j++)
                        {
                            plantRowFour[j].gameObject.GetComponent<Plant>().detectEnemy = true;
                        }
                        break;
                    case 4:
                        for (int j = 0; j < plantRowFive.Length; j++)
                        {
                            plantRowFive[j].gameObject.GetComponent<Plant>().detectEnemy = true;
                        }
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
                        for (int j = 0; j < plantRowOne.Length; j++)
                        {
                            plantRowOne[j].gameObject.GetComponent<Plant>().detectEnemy = false;
                        }
                        break;
                    case 1:
                        for (int j = 0; j < plantRowTwo.Length; j++)
                        {
                            plantRowTwo[j].gameObject.GetComponent<Plant>().detectEnemy = false;
                        }
                        break;
                    case 2:
                        for (int j = 0; j < plantRowThree.Length; j++)
                        {
                            plantRowThree[j].gameObject.GetComponent<Plant>().detectEnemy = false;
                        }
                        break;
                    case 3:
                        for (int j = 0; j < plantRowFour.Length; j++)
                        {
                            plantRowFour[j].gameObject.GetComponent<Plant>().detectEnemy = false;
                        }
                        break;
                    case 4:
                        for (int j = 0; j < plantRowFive.Length; j++)
                        {
                            plantRowFive[j].gameObject.GetComponent<Plant>().detectEnemy = false;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
