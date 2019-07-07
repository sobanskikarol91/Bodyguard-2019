using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ReturnToPoolOnDeath : ReturnToPool
{
    IDeath death;

    private void Awake()
    {
        death = GetComponent<IDeath>();
        death.Death += ReturnObjectToPool;
    }
}