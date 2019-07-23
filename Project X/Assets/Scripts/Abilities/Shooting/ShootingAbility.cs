using System.Collections;
using UnityEngine;


public class ShootingAbility : MonoBehaviour
{
    [SerializeField] ShootingType type;
    [SerializeField] Weapon weapon;
    [SerializeField] Transform bulletSpawnPoint;

    private float leftTimeToShot;
    private ShootingType typeInstance;

    private void Awake()
    {
        typeInstance = Instantiate(type);
        typeInstance.Init(TryShoot);
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
        leftTimeToShot = 0;
    }
}