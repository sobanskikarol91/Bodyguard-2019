using UnityEngine;

public class ShootingAbility : MonoBehaviour
{
    public Weapon Weapon { get; private set; }

    [SerializeField] ShootingType type;

    private ShootingType typeInstance;


    private void Awake()
    {
        Weapon = GetComponentInChildren<Weapon>();
        CreateShootingType();
    }

    private void Update()
    {
        type.Execute();
    }

    private void CreateWeapon(WeaponSettings newWeapon)
    {
        //Weapon = Instantiate(newWeapon);
        //Weapon.Init(this);
    }

    private void CreateShootingType()
    {
        typeInstance = Instantiate(type);
        typeInstance.Init(this);
    }

    public void Set(WeaponSettings newWeapon)
    {
        CreateWeapon(newWeapon);
    }
}