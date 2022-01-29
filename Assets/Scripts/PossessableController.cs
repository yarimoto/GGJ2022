using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessableController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float defaultSpeed = 2f;
    private float speed;

    public bool isPossessed = false;

    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPossessed)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            if (Input.GetButtonDown("Split"))
            {
                Unpossess();
                GameObject spirit = Instantiate(gameController.spiritPrefab);
                spirit.transform.position = transform.position;
            }
        }
    }
    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    public void Possess()
    {
        isPossessed = true;
        //this.gameObject.GetComponent<Collider2D>().isTrigger = false;
        speed = defaultSpeed;
    }

    public void Unpossess()
    {
        isPossessed = false;
        //this.gameObject.GetComponent<Collider2D>().isTrigger = true;
        speed = 0f;
    }
}
