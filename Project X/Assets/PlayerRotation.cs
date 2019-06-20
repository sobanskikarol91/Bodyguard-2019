using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : Rotation
{
    protected override Vector2 Direction()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }
}
