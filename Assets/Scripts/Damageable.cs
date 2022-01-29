using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PlayerBullet"))
        {
            currentHealth -= 10;
            Destroy(collider.gameObject);
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
