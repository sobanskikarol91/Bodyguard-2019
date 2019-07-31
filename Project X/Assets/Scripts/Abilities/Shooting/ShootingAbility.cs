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
        CreateWeapon(weapon);
        CreateShootingType();
    }

    private void CreateWeapon(Weapon newWeapon)
    {
        Weapon = Instantiate(newWeapon);
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

    public void Set(Weapon newWeapon)
    {
        Debug.Log("Create new Weapon: " + newWeapon.name);
        CreateWeapon(newWeapon);
    }
}