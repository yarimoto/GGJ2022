using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    GameController gameController;

    public float defaultSpeed = 2f;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        body = GetComponent<Rigidbody2D>();
        speed = defaultSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
            body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    public void SummonSpirit()
    {
        GameObject spirit = Instantiate(gameController.spiritPrefab);
        spirit.transform.position = transform.position;
        speed = 0;
    }

    public void GetSpiritBack()
    {
        speed = defaultSpeed;
    }
}
