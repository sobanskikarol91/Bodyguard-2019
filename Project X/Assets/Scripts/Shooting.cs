using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shooting : MonoBehaviour
{
    [SerializeField] float refireRate = 1f;
    IShootingInput input;

    private float leftTimeToShot;

    private void Awake()
    {
        input = GetComponent<IShootingInput>();
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
        leftTimeToShot = refireRate;

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
        Transform bullet = SimpleBulletPool.instance.Get().transform;
        bullet.rotation = transform.rotation;
        bullet.transform.position = transform.position;
        StartCoroutine(DecreaseTimeToFire());
    }
}