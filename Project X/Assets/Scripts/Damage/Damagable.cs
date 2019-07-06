using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    [SerializeField] protected ObjectType[] damageObjects;
    [SerializeField] protected GameObject effect;
    [SerializeField] protected float damage;

    public event Action Damage = delegate { };

    protected bool IsHitTargetOnDamageObjectsCollection(InteractiveObject target)
    {
        return damageObjects.Contains(target.Type);
    }

    protected void OnDamage()
    {
        Damage();
    }
}
