using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickMovement : Joystick, IMovementInput
{
    public Vector2 Movement => MoveDirection;

    protected override bool IsTouchConditionMet()
    {
        return Input.mousePosition.x > Screen.width / 2;
    }
}
