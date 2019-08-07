using System;
using UnityEngine;


public abstract class Weapon : ScriptableObject
{
    public Damagable Bullet { get { return bullet; } }
    public float RefireRate { get { return refireRate; } }

    [SerializeField] Damagable bullet;
    [SerializeField] float refireRate = 0.1f;
    [SerializeField] protected ObjectType[] damageObjects;
    [SerializeField] ShootingEffect[] effects;
    [SerializeField] AudioClip shotSnd;

    protected Transform bulletSpawnPoint;

    public virtual void Init(Transform bulletSpawnPoint)
    {
        this.bulletSpawnPoint = bulletSpawnPoint;
    }

    public void Shoot()
    {
        GameObject bullet = CreateBullet();
        ShowEffects(bullet);
    }

    private void ShowEffects(GameObject bullet)
    {
        Array.ForEach(effects, e => e.CreateEffect(bullet.transform));
        if (shotSnd) AudioSource.PlayClipAtPoint(shotSnd, bulletSpawnPoint.position);
    }

    protected abstract GameObject CreateBullet();
}
