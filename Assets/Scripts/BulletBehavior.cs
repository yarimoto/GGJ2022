using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 5f;
    public float ttl = 5f;
    public Vector3 direction = new Vector3(0, -1, 0);


    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, ttl);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction.normalized * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Walls"))
        {
            Destroy(this.gameObject);
        }
    }
}
