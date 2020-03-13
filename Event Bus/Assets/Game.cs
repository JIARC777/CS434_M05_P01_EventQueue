using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private bool m_IsQuitting;

    private void OnEnable()
    {
        EventBus.StartListening("Game", PlayMinecraft);
    }

    private void OnApplicationQuit()
    {
        // Any monobehavior can subscribe to to know its shutting down
        m_IsQuitting = true;
    }

    private void OnDisable()
    {
        if (m_IsQuitting == false)
        {

            // This all makes sure you dont try to shut down after event bus is gone
            EventBus.StopListening("Game", PlayMinecraft);
        }
    }

    void PlayMinecraft()
    {
        Debug.Log("Receiving a request to Game: Playing Minecraft");
    }
}

