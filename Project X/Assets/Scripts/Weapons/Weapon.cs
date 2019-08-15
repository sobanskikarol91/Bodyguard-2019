using UnityEngine;

public class Weapon : MonoBehaviour, IAttack
{
    [SerializeField] WeaponSettings settings;
    [SerializeField] Transform bulletSpawnPoint;

    public Transform BulletSpawnPoint => bulletSpawnPoint;
    public WeaponSettings Settings => settings;

    private WeaponSettings settingsInstance;
    private Animator animator;
    private bool isReadyToAttack => leftTimeToShot <= 0;
    private float leftTimeToShot;


    private void Awake()
    {
        settingsInstance = Instantiate(settings);
        animator = GetComponent<Animator>();
        settingsInstance.Init(this);
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
        settingsInstance.Shoot();
    }
}
