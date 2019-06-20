using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private void OnValidate()
    {
        type = ObjectType.Enemy;
    }
}
