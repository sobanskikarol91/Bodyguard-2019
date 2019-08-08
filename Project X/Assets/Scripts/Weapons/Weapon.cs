using System;
using UnityEngine;


public abstract class Weapon : ScriptableObject
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
    protected ShootingAbility ability;

    public virtual void Init(ShootingAbility ability)
    {
        this.ability = ability;
        bulletSpawnPoint = ability.BulletSpawnPoint;
    }

    public void Shoot()
    {
        GameObject bullet = CreateBullet();
        ShowEffects(bullet);
    }

    private void ShowEffects(GameObject bullet)
    {
        Array.ForEach(characterEffects, e => e.CreateEffect(ability.transform));
        Array.ForEach(bulletEffects, e => e.CreateEffect(bullet.transform));

        if (shotSnd) AudioSource.PlayClipAtPoint(shotSnd, bulletSpawnPoint.position);
    }

    protected abstract GameObject CreateBullet();
}
