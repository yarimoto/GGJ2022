using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float defaultSpeed = 2f;
    private float speed;

    public bool spiritOn = false;

    public GameObject spiritPrefab;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        speed = defaultSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
       
        if (Input.GetButtonDown("Split"))
        {
            if (spiritOn)
            {
                spiritOn = false;
                speed = defaultSpeed;
            } else
            {
                spiritOn = true;
                speed = 0;
                SummonSpirit();
            }
        }
    }

    private void FixedUpdate()
    {
            body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    private void SummonSpirit()
    {
        Instantiate(spiritPrefab, this.transform);
    }
}
