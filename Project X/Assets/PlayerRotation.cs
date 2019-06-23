using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : Rotation
{
    IRotateInput input;

    protected override Vector2 Direction { get => (Vector3)input.Direction; }

    private void Start()
    {
        input = GetComponent<IRotateInput>();
        input.OnUse += Rotate;
    }
}
