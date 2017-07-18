using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    public float cooldownTimer;
    public float evadeTime; // this tells us how long the evade takes
    public float evadeDistance; // this tells us how far player will evade
    public bool evading;
    public float evadeTimer;

    void ProcessEvasion()
    {
        cooldownTimer = Mathf.Max(0f, cooldownTimer - Time.deltaTime);

        if (!evading && cooldownTimer == 0 && Input.GetKeyDown("space")) 
        {
            evading = true;
            evadeTimer = evadeTime;
        }

        if (evading)
        {
            evadeTimer = Mathf.Max(0f, evadeTimer - Time.deltaTime);

            // Evasion overrides speed and direction
            moveDirection = playerRotation.transform.forward; // evasion = full speed forward
            moveSpeed = evadeDistance / evadeTime;

            if (evadeTimer == 0)
            {
                evading = false;
            }
        }
    }
}