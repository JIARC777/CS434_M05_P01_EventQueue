using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private bool m_IsQuitting;
    private bool hasLaunched = false;

    private void OnEnable()
        {
            EventBus.StartListening("Launch", LaunchRocket);
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
                EventBus.StopListening("Launch", LaunchRocket);
            }
        }

        void LaunchRocket()
        {
            if (!hasLaunched)
            {
                hasLaunched = true;
                Debug.Log("Receiving a Launch Event: Launching Rocket");
            }
            
        }
}
