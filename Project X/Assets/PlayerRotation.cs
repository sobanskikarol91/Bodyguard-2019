using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : Rotation
{
    IRotationInput input;

    private void Start()
    {
        input = GetComponent<IRotationInput>();
    }

    protected override Vector2 RotateDirection()
    {
        Debug.Log((Vector3)input.Rotate() - transform.position);
        return (Vector3)input.Rotate() - transform.position;
    }
}
