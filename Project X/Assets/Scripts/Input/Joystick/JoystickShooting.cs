﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickShooting : Joystick, IRotateInput
{
    protected override bool IsTouchConditionMet()
    {
        return Input.mousePosition.x > Screen.width / 2;
    }
}
