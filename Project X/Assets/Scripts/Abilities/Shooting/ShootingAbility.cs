using UnityEngine;

public class ShootingAbility : MonoBehaviour
{
    public Weapon Weapon => weapon;

    [SerializeField] ShootingType type;
    [SerializeField] Transform weaponSpot;
    [SerializeField] Weapon weapon;

    private ShootingType typeInstance;


    private void Awake()
    {
        if (weapon) Set(Weapon);
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

    public void Set(Weapon newWeapon)
    {
        RemovePreviousWeapon();
        weapon = ObjectPoolManager.instance.Get(newWeapon.gameObject).GetComponent<Weapon>();
        weapon.transform.SetParent(weaponSpot);
        weapon.transform.localRotation = Quaternion.Euler(Vector3.zero);
        weapon.transform.localPosition = Vector3.zero;
    }

    private void RemovePreviousWeapon()
    {
        if (Weapon) ObjectPoolManager.instance.ReturnToPool(Weapon.gameObject);
    }
}