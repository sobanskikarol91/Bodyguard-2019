using UnityEngine;

public class Weapon : MonoBehaviour, IAttack
{
    [SerializeField] WeaponSettings settings;
    [SerializeField] Transform bulletSpawnPoint;

    public Transform BulletSpawnPoint => bulletSpawnPoint;
    public WeaponSettings Settings => settings;
    private Animator animator;
    private bool isReadyToAttack => leftTimeToShot <= 0;
    protected float leftTimeToShot;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        settings.Init(this);
        ResetTimeLeft();
    }

    private void ResetTimeLeft()
    {
        leftTimeToShot = Settings.RefireRate;
    }

    private void Update()
    {
        DecreaseTimeToShoot();
    }

    protected void DecreaseTimeToShoot()
    {
        leftTimeToShot -= Time.deltaTime;
    }

    public void Attack()
    {
        if (!isReadyToAttack) return;

        animator.SetTrigger("attack");
        ResetTimeLeft();
        settings.Shoot();
    }
}
