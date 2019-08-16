using System;
using UnityEngine;


public abstract class WeaponSettings : ScriptableObject
{
    public Damagable Bullet { get => bullet; }
    public float RefireRate { get => refireRate; }

    [SerializeField] Damagable bullet;
    [SerializeField] float refireRate = 0.1f;
    [SerializeField] protected ObjectType[] damageObjects;
    [SerializeField] AudioClip shotSnd;

    [Header("Effects")]
    [SerializeField] ShootingEffect[] bulletEffects;
    [SerializeField] ShootingEffect[] characterEffects;


    protected Transform bulletSpawnPoint;
    protected Weapon weapon;


    public virtual void Init(Weapon weapon)
    {
        this.weapon = weapon;
        bulletSpawnPoint = weapon.BulletSpawnPoint;
    }

    public void Shoot()
    {
        GameObject bullet = CreateBullet();
        ShowEffects(bullet);
    }

    private void ShowEffects(GameObject bullet)
    {
        Array.ForEach(characterEffects, e => e.CreateEffect(weapon.transform));
        Array.ForEach(bulletEffects, e => e.CreateEffect(bullet.transform));

        if (shotSnd) AudioSourceFactory.PlayClipAtPoint(shotSnd, bulletSpawnPoint);
    }

    protected abstract GameObject CreateBullet();
}
