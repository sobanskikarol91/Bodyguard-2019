using UnityEngine;

public class ShootingAbility : MonoBehaviour
{
    public Weapon Weapon { get; private set; }

    [SerializeField] ShootingType type;
    [SerializeField] Weapon weapon;
    [SerializeField] Transform bulletSpawnPoint;

    private ShootingType typeInstance;

    private void Awake()
    {
        CreateWeapon();
        CreateShootingType();
    }

    private void CreateWeapon()
    {
        Weapon = Instantiate(weapon);
        Weapon.Init(bulletSpawnPoint);
    }

    private void CreateShootingType()
    {
        typeInstance = Instantiate(type);
        typeInstance.Init(this);
    }

    private void Update()
    {
        typeInstance.Execute();
    }

    public void Set(Weapon weapon)
    {
        this.weapon = weapon;
    }
}