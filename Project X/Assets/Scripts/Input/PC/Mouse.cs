using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Mouse", menuName = "Input/PC/Mouse")]
public class Mouse : TwoAxisInput
{
    private Camera camera;

    private void OnEnable()
    {
        camera = Camera.main;  
    }

    public override void Execute()
    {
        Direction = camera.ScreenToWorldPoint(Input.mousePosition);
        base.OnInputUsing();
    }
}