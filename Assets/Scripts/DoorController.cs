using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool permanentlyOpen = false;
    public int platesNeeded;
    public int pressedPlates = 0;

    public bool isOpen;

    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        boxCollider = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddPlate()
    {
        pressedPlates++;
        CheckPlates();
    }
    public void RemovePlate()
    {
        pressedPlates--;
        CheckPlates();
    }
    private void Close()
    {
        spriteRenderer.enabled = true;
        boxCollider.enabled = true;
        isOpen = false;
    }
    private void Open()
    {
        spriteRenderer.enabled = false;
        boxCollider.enabled = false;
        isOpen = true;
    }
    public void CheckPlates()
    {
        if (pressedPlates >= platesNeeded)
        {
            if(!isOpen)
            {
                Open();
            } 
        } else
        {
            if (isOpen)
            {
                if (!permanentlyOpen)
                {
                    Close();
                }
            }
        }
    }


}
