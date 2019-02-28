using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInterface : MonoBehaviour
{
    public enum JoyConLeft {
        None = KeyCode.None,

        A = KeyCode.Joystick1Button0,
        B = KeyCode.JoystickButton1,
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        //Debug.Log(JoyConLeft.A);
    }
}
