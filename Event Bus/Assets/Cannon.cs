using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private bool m_IsQuitting;

    private void OnEnable()
    {
        EventBus.StartListening("Shoot", ShootCannon);
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
            EventBus.StopListening("Shoot", ShootCannon);
        }
    }

    void ShootCannon()
    {
        Debug.Log("Receiving a Shoot Event: Shooting Cannon");
    }
}
