using UnityEngine;

public class ShootingAbility : MonoBehaviour
{
    public Weapon Weapon { get; private set; }

    [SerializeField] ShootingType type;
    [SerializeField] Transform weaponSpot;

    private ShootingType typeInstance;


    private void Awake()
    {
        Weapon = GetComponentInChildren<Weapon>();
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
        Weapon = ObjectPoolManager.instance.Get(newWeapon.gameObject).GetComponent<Weapon>();
        Weapon.transform.SetParent(weaponSpot);
        Weapon.transform.localRotation = Quaternion.Euler(Vector3.zero);
        Weapon.transform.localPosition = Vector3.zero;
    }

    private void RemovePreviousWeapon()
    {
        if (Weapon) ObjectPoolManager.instance.ReturnToPool(Weapon.gameObject);
    }
}