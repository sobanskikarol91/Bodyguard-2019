using System;
using System.Collections;
using UnityEngine;

public class ShootingAbility : MonoBehaviour
{
    [SerializeField] ShootingType type;
    [SerializeField] Weapon weapon;
    [SerializeField] Transform bulletSpawnPoint;

    private float leftTimeToShot;
    private ShootingType typeInstance;
    public event Action ReadyToShoot = delegate { };


    private void Awake()
    {
        typeInstance = Instantiate(type);
        typeInstance.Init(this);
    }

    public void TryShoot()
    {
        if (IsReadyToFire())
            ShotEffect();
    }

    private bool IsReadyToFire()
    {
        return leftTimeToShot == 0;
    }

    private IEnumerator DecreaseTimeToFire()
    {
        leftTimeToShot = weapon.RefireRate;

        while (leftTimeToShot > 0)
        {
            leftTimeToShot -= Time.deltaTime;
            if (leftTimeToShot < 0) break;
            yield return null;
        }

        leftTimeToShot = 0;
        ReadyToShoot();
    }

    public void ShotEffect()
    {
        weapon.Shoot(bulletSpawnPoint);
        StartCoroutine(DecreaseTimeToFire());
    }

    private void OnEnable()
    {
        StartCoroutine(DecreaseTimeToFire());
        leftTimeToShot = 0;
    }

    public void Set(Weapon weapon)
    {
        StopAllCoroutines();
        this.weapon = weapon;
        StartCoroutine(DecreaseTimeToFire());
    }
}