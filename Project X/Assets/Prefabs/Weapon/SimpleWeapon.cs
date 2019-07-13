using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Simple")]
public class SimpleWeapon : Weapon
{
    public override void Shoot(Transform transform)
    {
        Transform bullet = ObjectPoolManager.instance.Get(Bullet).transform;
        bullet.rotation = transform.rotation;
        bullet.transform.position = transform.position;
    }
}