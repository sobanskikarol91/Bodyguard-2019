using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Mouse", menuName = "Input/PC/Mouse")]
public class Mouse : TwoAxisInput
{
    public override void OnTouchEnd()
    {
       
    }

    public override void OnTouching(Touch touch)
    {
        Direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        OnInputUsing();
    }

    public override void OnTouchStart(Touch touch)
    {
       
    }
}