using UnityEngine;

public class ShootingAbility : MonoBehaviour
{
    public Weapon CurrentWeapon { get; private set; }

    [SerializeField] ShootingType type;
    [SerializeField] Transform weaponSpot;
    [SerializeField] Weapon defaultWeapon;

    private ShootingType typeInstance;

    private void OnEnable()
    {
        if (defaultWeapon) Set(defaultWeapon.gameObject);
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

    public void Set(GameObject newWeapon)
    {
        if(CurrentWeapon) RemovePreviousWeapon();
        CurrentWeapon = ObjectPoolManager.instance.Get(newWeapon).GetComponent<Weapon>();

        if (!CurrentWeapon)  return;

        CurrentWeapon.transform.SetParent(weaponSpot);
        CurrentWeapon.transform.localRotation = Quaternion.Euler(Vector3.zero);
        CurrentWeapon.transform.localPosition = Vector3.zero;
    }

    private void RemovePreviousWeapon()
    {
        if (CurrentWeapon) ObjectPoolManager.instance.ReturnToPool(CurrentWeapon.gameObject);
    }
}