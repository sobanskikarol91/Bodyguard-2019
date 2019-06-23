using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickMovement : Joystick, IMoveInput
{
    protected override bool IsTouchConditionMet()
    {
        return Input.mousePosition.x <= Screen.width / 2;
    }
}
