using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    public bool isActivated = false;
    public DoorController linkedDoor;

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
        } else
        {
            linkedDoor.RemovePlate();
        }
    }
}
