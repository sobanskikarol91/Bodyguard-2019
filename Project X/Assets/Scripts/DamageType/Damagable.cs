using System;
using System.Linq;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    [SerializeField] ObjectType[] damageObjects;
    [SerializeField] protected float Damage;

    public event Action DoDamage = delegate { };


    protected bool IsHitTargetOnDamageObjectsCollection(InteractiveObject target)
    {
        return damageObjects.Contains(target.Type);
    }

    protected void OnDamage()
    {
        DoDamage();
    }

    public void Init(float damage, ObjectType[] damageObjects)
    {
        this.damageObjects = damageObjects;
        Damage = damage;
    }
}