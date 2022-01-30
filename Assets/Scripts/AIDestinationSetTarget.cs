using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDestinationSetTarget : MonoBehaviour
{
    AIDestinationSetter script;

    void Start()
    {
        script = GetComponent<AIDestinationSetter>();
        script.target = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
