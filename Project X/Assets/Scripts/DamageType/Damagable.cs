using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    protected ObjectType[] damageObjects;
    protected float damage;

    public event Action Damage = delegate { };

    protected bool IsHitTargetOnDamageObjectsCollection(InteractiveObject target)
    {
        return damageObjects.Contains(target.Type);
    }

    protected void OnDamage()
    {
        Damage();
    }

    public void Init(float damage,ObjectType[] damageObjects )
    {
        this.damageObjects = damageObjects;
        this.damage = damage;
    }
}
