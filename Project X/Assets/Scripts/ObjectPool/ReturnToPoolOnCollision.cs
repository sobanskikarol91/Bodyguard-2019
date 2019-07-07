using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ReturnToPoolOnCollision : ReturnToPool
{
    private DamageOnCollision damageOnCollision;


    protected void Awake()
    {
        damageOnCollision = GetComponent<DamageOnCollision>();
    }

    private void OnEnable()
    {
        if (damageOnCollision != null)
            damageOnCollision.Damage += ReturnOnCollision;
    }

    private void OnDisable()
    {
        if (damageOnCollision != null)
            damageOnCollision.Damage -= ReturnOnCollision;
    }

    private void ReturnOnCollision()
    {
        damageOnCollision.Damage -= ReturnOnCollision;
        ObjectPoolManager.instance.ReturnToPool(gameObject);
    }
}