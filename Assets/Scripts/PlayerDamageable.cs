using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamageable : MonoBehaviour
{
    public Slider healthSlider;
    public int maxHealth = 3;
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthSlider.value = health;
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        healthSlider.value = health;
        if (health <= 0)
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().SetGameOver();
        }
    }
}
