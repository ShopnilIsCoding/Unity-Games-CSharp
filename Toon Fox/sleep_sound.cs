using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleep_sound : NewBehaviourScript
{
    public GameObject sleep;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        float verticalInput = joystick.Vertical;
        if (verticalInput == 0 && isGrounded == true)
        {
            sleep.SetActive(true);
        }
        else
        {
            sleep.SetActive(false);
        }
    }
}
