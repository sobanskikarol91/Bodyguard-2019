using UnityEngine;


public class JoystickMovement : Joystick, IMoveInput
{
    protected override bool IsTouchConditionMet()
    {
        return Input.mousePosition.x <= Screen.width / 2;
    }
}
