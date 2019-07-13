using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shooting : MonoBehaviour
{
    [SerializeField] TwoAxisInput input;
    [SerializeField] Weapon weapon;

    private float leftTimeToShot;


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
        leftTimeToShot = weapon.Settings.RefireRate;

        while (leftTimeToShot > 0)
        {
            leftTimeToShot -= Time.deltaTime;
            yield return null;

            if (leftTimeToShot < 0)
                break;
        }

        leftTimeToShot = 0;
    }

    private void ShotEffect()
    {
        weapon.Shoot(transform);
        StartCoroutine(DecreaseTimeToFire());
    }

    private void OnEnable()
    {
        input.InputStartUsing += TryShoot;
        leftTimeToShot = 0;
    }

    private void OnDisable()
    {
        input.InputStartUsing -= TryShoot;
    }
}