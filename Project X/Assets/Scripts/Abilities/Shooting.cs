using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shooting : MonoBehaviour
{
    [SerializeField] float refireRate = 1f;
    [SerializeField] TwoAxisInput input;
    [SerializeField] GameObject prefab;

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
        Transform bullet = ObjectPoolManager.instance.Get(prefab).transform;
        bullet.rotation = transform.rotation;

        bullet.transform.position = transform.position;
        StartCoroutine(DecreaseTimeToFire());
    }

    private void OnEnable()
    {
        input.InputStartUsing += TryShoot;
    }

    private void OnDisable()
    {
        input.InputStartUsing -= TryShoot;
    }
}