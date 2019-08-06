using System;
using UnityEngine;


[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Simple")]
public class SimpleWeapon : Weapon
{
    [SerializeField] ShootingEffect[] effects;
    public override void Shoot()
    {
        Transform bullet = ObjectPoolManager.instance.Get(Bullet.gameObject).transform;
        bullet.GetComponent<Damagable>()?.Init(damage, damageObjects);

        bullet.rotation = bulletSpawnPoint.rotation;
        bullet.transform.position = bulletSpawnPoint.position;

        Array.ForEach(effects, e => e.OnShoot(bullet));
    }
}