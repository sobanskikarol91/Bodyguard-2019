using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ReturnToPoolOnCollision : ReturnToPool
{
    private DamageOnCollision damageOnCollision;


    protected override void Awake()
    {
        base.Awake();

        damageOnCollision = GetComponent<DamageOnCollision>();

        if (damageOnCollision != null)
            damageOnCollision.Damage += ReturnOnCollision;
    }

    private void ReturnOnCollision()
    {
        objectToReturn.ReturnToPool();
        GetComponent<DamageOnCollision>().Damage -= ReturnOnCollision;
    }
}