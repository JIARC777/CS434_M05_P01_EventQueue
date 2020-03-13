using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPublisher : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            EventBus.AddToQueue("Shoot");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            EventBus.AddToQueue("Launch");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            EventBus.AddToQueue("makeSentient");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            EventBus.AddToQueue("Game");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            EventBus.AddToQueue("Hack");
        }
    }
}
