using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    public bool isActivated = false;
    public DoorController linkedDoor;

    public GameObject onImg;
    public GameObject offImg;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        isActivated = !isActivated;

        if (isActivated)
        {
            linkedDoor.AddPlate();
            onImg.SetActive(true);
            offImg.SetActive(false);
        } else
        {
            linkedDoor.RemovePlate();
            onImg.SetActive(false);
            offImg.SetActive(true);
        }
    }
}
