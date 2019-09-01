using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IAttack
{
    [SerializeField] WeaponSettings settings;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] GameObject shotSparks;

    public Transform BulletSpawnPoint => bulletSpawnPoint;
    public Damagable Bullet { get; private set; }

    private Animator animator;
    private bool IsReadyToAttack => leftTimeToShot <= 0;
    private float leftTimeToShot;
    private ShootingEffect[] bulletEffects;
    private ShootingEffect[] weaponEffects;
    private GameObject createdBullet;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        leftTimeToShot = 0;
    }

    private void ResetTimeLeft()
    {
        leftTimeToShot = settings.RefireRate;
    }

    private void Update()
    {
        DecreaseTimeToShoot();
    }

    protected void DecreaseTimeToShoot()
    {
        leftTimeToShot -= Time.deltaTime;
    }

    public void TryAttack()
    {
        if (!IsReadyToAttack) return;

        createdBullet = Attack();
        AudioSourceFactory.PlayClipAtPoint(settings.ShotSnd, bulletSpawnPoint);
        ShowEffects();
        animator.SetTrigger("attack");
        ResetTimeLeft();
    }

    public void Init(Damagable bullet, ShootingEffect[] bulletEffects, ShootingEffect[] weaponEffects)
    {
        this.bulletEffects = bulletEffects;
        this.weaponEffects = weaponEffects;
        Bullet = bullet;
    }

    private void ShowEffects()
    {
        CreateSparks();
        Array.ForEach(bulletEffects, e => e.CreateEffect(createdBullet.transform));
        Array.ForEach(weaponEffects, e => e.CreateEffect(transform));
    }

    private void CreateSparks()
    {
        GameObject sparks = ObjectPoolManager.instance.Get(shotSparks);
        sparks.transform.SetParent(bulletSpawnPoint, false);
    }

    protected abstract GameObject Attack();
}

[Serializable]
public class WeaponSettings
{
    public float RefireRate { get => refireRate; }
    public AudioClip ShotSnd { get => shotSnd; }

    [SerializeField] float refireRate = 0.1f;
    [SerializeField] AudioClip shotSnd;
}