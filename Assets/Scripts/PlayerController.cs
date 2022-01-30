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

        //Se tourner vers la souris
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 180f));
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
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
