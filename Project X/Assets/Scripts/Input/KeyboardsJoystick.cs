using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class KeyboardsJoystick: TwoAxisInput
{
    [SerializeField] string horizontalAxis = "Horizontal";
    [SerializeField] string verticalAxis = "Vertical";


    private void Update()
    {
        float verticalMove = Input.GetAxis(verticalAxis);
        float horizontalMove = Input.GetAxis(horizontalAxis);

        Direction = new Vector2(horizontalMove, verticalMove);

        OnInputUsing();
    }
}