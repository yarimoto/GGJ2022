using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamageDealing : MonoBehaviour
{
    public float attackSpeed = 2.0f;
    public int dmg = 1;
    private float elapsedTime = 2.0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (elapsedTime >= attackSpeed && collider.CompareTag("Player"))
        {
            // Damage
            collider.gameObject.GetComponent<PlayerDamageable>().TakeDamage(dmg);
            elapsedTime = 0.0f;
        }
    }
}
