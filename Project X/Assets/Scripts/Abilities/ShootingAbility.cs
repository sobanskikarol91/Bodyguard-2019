using System.Collections;
using UnityEngine;


public class ShootingAbility : MonoBehaviour, IInput
{
    [SerializeField] Weapon weapon;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] InputHandler input;

    public InputHandler Input { get => input; set => input = value; }
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
        leftTimeToShot = weapon.RefireRate;

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
        weapon.Shoot(bulletSpawnPoint);
        StartCoroutine(DecreaseTimeToFire());
    }

    private void OnEnable()
    {
        input.EndUsing += TryShoot;
        leftTimeToShot = 0;
    }

    private void OnDisable()
    {
        input.EndUsing -= TryShoot;
    }
}