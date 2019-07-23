using System;
using UnityEngine;


public abstract class Weapon : ScriptableObject
{
    public Damagable Bullet { get { return bullet; } }
    public float RefireRate { get { return refireRate; } }

    [SerializeField] Damagable bullet;
    [SerializeField] float refireRate = 0.1f;
    [SerializeField] protected ObjectType[] damageObjects;
    [SerializeField] protected float damage;


    public abstract void Shoot(Transform shotPosition);
}
