using System;
using UnityEngine;


public abstract class Weapon : ScriptableObject
{
    public Damagable Bullet { get { return bullet; } }
    public float RefireRate { get { return refireRate; } }

    [SerializeField] Damagable bullet;
    [SerializeField] float refireRate = 0.1f;
    [SerializeField] protected float damage;
    [SerializeField] protected ObjectType[] damageObjects;
    [SerializeField] ShootingEffect[] effects;

    protected Transform bulletSpawnPoint;

    public virtual void Init(Transform bulletSpawnPoint)
    {
        this.bulletSpawnPoint = bulletSpawnPoint;
    }

    public void Shoot()
    {
        Debug.Log("s");
        GameObject bullet = CreateBullet();
        ShowEffects(bullet);
    }

    private void ShowEffects(GameObject bullet)
    {
        Debug.Log("effects");
        Array.ForEach(effects, e => e.CreateEffect(bullet.transform));
    }

    protected abstract GameObject CreateBullet();
}
