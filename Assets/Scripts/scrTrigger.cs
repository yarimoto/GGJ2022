using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class scrTrigger : MonoBehaviour
{
    public GameObject pack;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            for (int i = 0; i < pack.transform.childCount; i++)
            {
                pack.transform.GetChild(i).GetComponent<AIPath>().canMove = true;
            }
            gameObject.SetActive(false);
        }
        
    }
}
