using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IAttack
{
    [SerializeField] WeaponSettings settings;
    [SerializeField] Transform bulletSpawnPoint;

    public Transform BulletSpawnPoint => bulletSpawnPoint;
    public Damagable Bullet { get; private set; }

    private Animator animator;
    private bool isReadyToAttack => leftTimeToShot <= 0;
    private float leftTimeToShot;


    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        ResetTimeLeft();
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
        if (!isReadyToAttack) return;

        GameObject bullet = Attack();
        AudioSourceFactory.PlayClipAtPoint(settings.ShotSnd, bulletSpawnPoint);
        // ShowEffects();
        animator.SetTrigger("attack");
        ResetTimeLeft();
    }

    public void SetBullet(Damagable bullet)
    {
        Bullet = bullet;
    }

    private void ShowEffects(GameObject bullet)
    {
        //Array.ForEach(characterEffects, e => e.CreateEffect(weapon.transform));
        //Array.ForEach(bulletEffects, e => e.CreateEffect(bullet.transform));
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