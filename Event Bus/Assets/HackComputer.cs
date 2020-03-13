using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackComputer : MonoBehaviour
{
    private bool m_IsQuitting;

    private void OnEnable()
    {
        EventBus.StartListening("Hack", BufferOverflow);
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
            EventBus.StopListening("Hack", BufferOverflow);
        }
    }

    void BufferOverflow()
    {
        Debug.Log("0101001010101010101010010101010101010110101010101010101010101010101010101010101010" +
            " Unity Sourcecode Accessed through buffer overflow");
    }
}
