using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/MultipleBullets")]
public class MultipleBulletWeapon : Weapon
{
    [SerializeField, Tooltip("Angle between bullets")] int amount;
    [SerializeField, Tooltip("Angle between bullets")] float angle;


    public override void Shoot(Transform transform)
    {
        float playerRotation = transform.rotation.eulerAngles.z;

        GameObject[] bullets = ObjectPoolManager.instance.Get(Bullet, amount);

        for (int i = 0; i < amount; i++)
        {
            Vector3 rotation = new Vector3(0, 0, playerRotation + i * angle);
            bullets[i].transform.rotation = Quaternion.Euler(rotation);
            bullets[i].transform.position = transform.position;
        }
    }
}