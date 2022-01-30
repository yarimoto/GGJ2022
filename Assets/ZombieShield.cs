using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieShield : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PlayerBullet"))
        {
            Destroy(collider.gameObject);
        }
    }
}
