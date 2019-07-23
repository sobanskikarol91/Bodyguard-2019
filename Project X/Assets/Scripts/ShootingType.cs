using System;
using UnityEngine;


public abstract class ShootingType : ScriptableObject 
{
    protected Action TryShoot;

    public virtual void Init(Action TryShoot)
    {
        this.TryShoot = TryShoot;
    }
}