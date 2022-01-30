using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    public bool isPressed = false;
    public DoorController linkedDoor;

    public GameObject pressedImg;
    public GameObject notpressedImg;

    private int objects = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Possessable" || collision.gameObject.tag == "Player")
        {
            objects++;
            if(objects == 1)
            {
                isPressed = true;
                linkedDoor.AddPlate();
                pressedImg.SetActive(true);
                notpressedImg.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Possessable" || collision.gameObject.tag == "Player")
        {
            objects--;
            if(objects == 0)
            {
                isPressed = false;
                linkedDoor.RemovePlate();
                pressedImg.SetActive(false);
                notpressedImg.SetActive(true);
            }
        }
    }
}
