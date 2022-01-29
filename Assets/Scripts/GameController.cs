using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool spiritOn;
    public GameObject spiritPrefab;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Split"))
        {
            if (!spiritOn)
            {
                SummonSpirit();
            }
        }
    }
    public void SummonSpirit()
    {
        spiritOn = true;
        player.SummonSpirit();
    }

    public void DestroySpirit()
    {
        spiritOn = false;
        player.GetSpiritBack();
    }
}
