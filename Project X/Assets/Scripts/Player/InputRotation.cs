using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRotation : Rotation
{
    protected override Vector2 Direction { get => (Vector3)input.Direction; }

    private TwoAxisInput input;

    private void OnEnable()
    {
        input = GameManager.instance.Input.Rotation;
        input.InputUsing += Rotate;
    }

    private void OnDisable()
    {
        input.InputUsing -= Rotate;
    }
}
