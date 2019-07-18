using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRotation : Rotation
{
    protected override Vector2 Direction { get => (Vector3)input.Direction; }
    [SerializeField] TwoAxisInput input;

    private void Start()
    {
        //input.InputUsing += Rotate;
    }
}
