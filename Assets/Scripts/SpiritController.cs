using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    PlayerController player;

    public float speed = 2f;

    public bool spiritOn;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        spiritOn = player.spiritOn;

        if (!spiritOn)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
}
