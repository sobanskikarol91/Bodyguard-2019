using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    protected override void Awake()
    {
        base.Awake();
        type = ObjectType.Enemy;
    }
}
