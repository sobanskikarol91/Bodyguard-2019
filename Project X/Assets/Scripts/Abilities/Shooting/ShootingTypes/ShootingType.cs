using System;
using UnityEngine;

public abstract class ShootingType : AbilityType<ShootingAbility>
{
    public event Action ReadyToShoot = delegate { };
    protected float leftTimeToShot;

    
    public override void Init(ShootingAbility ability)
    {
        base.Init(ability);
    }

    protected void DecreaseTimeToShoot()
    {
        leftTimeToShot -= Time.deltaTime;
    }

    protected void TryShoot()
    {
        if (IsReadyToFire())
            OnReadyToFire();
    }

    void OnReadyToFire()
    {
        ReadyToShoot();
        leftTimeToShot = ability.Weapon.RefireRate;
        ability.Weapon.Shoot();
    }

    private bool IsReadyToFire()
    {
        return leftTimeToShot <= 0;
    }
}