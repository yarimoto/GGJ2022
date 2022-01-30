using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    PlayerController player;
    GameController gameController;

    public float speed = 2f;

    public bool spiritOn;

    public GameObject currentPossessable;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (!gameController.spiritOn)
        {
            Destroy(this.gameObject);
        }

        if (Input.GetButtonDown("Split"))
        {
            if (currentPossessable != null)
            {
                if (currentPossessable.tag == "Player")
                {
                    gameController.DestroySpirit();
                } else if (currentPossessable.tag == "Possessable")
                {
                    currentPossessable.GetComponent<PossessableController>().Possess();
                    Destroy(this.gameObject);
                } else if (currentPossessable.tag == "Computer")
                {
                    currentPossessable.GetComponent<ComputerController>().Activate();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if(collision.gameObject.tag == "Possessable" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Computer")
        {
            currentPossessable = collision.gameObject;
            Debug.Log("Possession possible");
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Possessable" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Computer")
        {
            currentPossessable = null;
            Debug.Log("Plus de possession possible");
        }
    }
}
