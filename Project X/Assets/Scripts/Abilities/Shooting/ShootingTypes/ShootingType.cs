using System;
using UnityEngine;

public abstract class ShootingType : AbilityType<ShootingAbility>
{
    public event Action ReadyToShoot = delegate { };
    protected float leftTimeToShot;
    private float timeToShot;

    public override void Init(ShootingAbility ability)
    {
        base.Init(ability);
        timeToShot = ability.Weapon.RefireRate;
    }

    public override void Execute()
    {
        DecreaseTimeToShoot();
        TryShoot();
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
        leftTimeToShot = timeToShot;
        ability.Weapon.Shoot();
    }

    private bool IsReadyToFire()
    {
        return leftTimeToShot <= 0;
    }
}