using UnityEngine;

public class ShootingAbility : Ability
{
    public Weapon CurrentWeapon { get; private set; }

    [SerializeField] ShootingType type;
    [SerializeField] Transform weaponSpot;
    [SerializeField] LevelWeapon defaultWeapon;

    private ShootingType typeInstance;

    private void OnEnable()
    {
        if (defaultWeapon) Set(defaultWeapon);
        CreateShootingType();
    }

    private void Update()
    {
        typeInstance.Execute();
    }

    private void CreateShootingType()
    {
        typeInstance = Instantiate(type);
        typeInstance.Init(this);
    }

    public void Set(LevelWeapon newWeapon)
    {
        if (CurrentWeapon) RemovePreviousWeapon();

        CurrentWeapon = ObjectPoolManager.instance.Get(newWeapon.Model).GetComponent<Weapon>();
        Damagable bullet = newWeapon.Bullet.GetComponent<Damagable>();
        CurrentWeapon.Init(bullet, newWeapon.BulletEffects, newWeapon.WeaponEffects);
        CurrentWeapon.transform.SetParent(weaponSpot, false);
    }

    private void OnDisable()
    {
        RemovePreviousWeapon();
    }

    private void RemovePreviousWeapon()
    {
        if (CurrentWeapon) CurrentWeapon.gameObject.SetActive(false);
    }
}