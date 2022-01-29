using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageable : MonoBehaviour
{
    public int maxHealth = 3;
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        Debug.Log(health);
        if (health <= 0)
        {
            Debug.Log("ded");
            // Dead
        }
    }
}
