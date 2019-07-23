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
        StartCoroutine(DecreaseTimeToFire());
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
        Debug.Log("Prepare: " + gameObject.name + " "  + leftTimeToShot);

        while (leftTimeToShot > 0)
        {
            Debug.Log("Time0: " + gameObject.name + " " + leftTimeToShot);
            leftTimeToShot -= Time.deltaTime;
            Debug.Log("Time1: " + gameObject.name + " " + leftTimeToShot);
            yield return null;
            Debug.Log("Time2: " + gameObject.name + " " + leftTimeToShot);
            if (leftTimeToShot < 0)
                break;

            Debug.Log("Time3: " + gameObject.name + " " + leftTimeToShot);
        }

        leftTimeToShot = 0;
        Debug.Log("Ready: " + gameObject.name);
       // ReadyToShoot();
    }

    public void ShotEffect()
    {
        weapon.Shoot(bulletSpawnPoint);
        StartCoroutine(DecreaseTimeToFire());
    }

    private void OnEnable()
    {
        leftTimeToShot = 0;
    }
}