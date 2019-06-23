using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : Rotation
{
    IRotateInput input;

    private void Start()
    {
        input = GetComponent<IRotateInput>();
    }

    protected override Vector2 RotateDirection()
    {
        if (input.Direction != Vector2.zero)
            return (Vector3)input.Direction - transform.position;
        else
            return Vector2.zero;
    }
}
