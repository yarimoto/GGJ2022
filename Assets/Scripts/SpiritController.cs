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

    private PossessableController currentPossessable;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        //Ignorer les collisions avec le joueur
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
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

        if (Input.GetButtonDown("Interact"))
        {
            if(currentPossessable != null)
            {
                currentPossessable.Possess();
                Destroy(this.gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Possessable")
        {
            currentPossessable = collision.gameObject.GetComponent<PossessableController>();
            Debug.Log("Armure détectée");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Possessable")
        {
            currentPossessable = null;
            Debug.Log("Armure quittée");
        }
    }
}
