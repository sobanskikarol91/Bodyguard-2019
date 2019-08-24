using UnityEngine;

public class WeaponLvlManager : MonoBehaviour, IDependsOnLvl, IRestart
{
    [SerializeField] GameWeaponsSettings weaponSettings;
    private ShootingAbility playerShootingAbility;

    private void Start()
    {
        playerShootingAbility = GameManager.instance.Player.GetComponentInChildren<ShootingAbility>();
        OnRestart();
    }

    public void OnGainNextLvl(int lvl)
    {
        if (lvl < weaponSettings.Weapons.Length)
            playerShootingAbility?.Set(weaponSettings.Weapons[lvl]);
    }

    public void OnRestart()
    {
        playerShootingAbility?.Set(weaponSettings.Weapons[0]);
    }
}