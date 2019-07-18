using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "MobileInput", menuName = "Input/PC")]
public class PCInput : InputManager
{
    public override TwoAxisInput Movement { get { return keyboardJoystick; } protected set { Movement = value; } }
    public override TwoAxisInput Rotation { get { return keyboardJoystick; } protected set { Rotation = value; } }

    [SerializeField] KeyboardsJoystick keyboardJoystick;


    public override void Execute()
    {
        keyboardJoystick.OnTouchStart(new Touch());
    }

    public override void Init()
    {
        keyboardJoystick = new KeyboardsJoystick();
    }
}