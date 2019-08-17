using System;
using System.Linq;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    [SerializeField] protected float Damage;
    [SerializeField] protected ObjectType[] damageObjects;

    public event Action DoDamage = delegate { };

    protected bool IsHitTargetOnDamageObjectsCollection(InteractiveObject target)
    {
        return damageObjects.Contains(target.Type);;
    }

    protected void OnDamage()
    {
        DoDamage();
    }

    public void ChangeDamage(float damage)
    {
        Damage = damage;
    }
}