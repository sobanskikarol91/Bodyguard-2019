using UnityEngine;

public class WeaponLvlManager : MonoBehaviour, IDependsOnLvl, IRestart
{
    [SerializeField] WeaponLvlSetting weaponSettings;
    private ShootingAbility playerShootingAbility;

    private void Start()
    {
        playerShootingAbility = GameManager.instance.Player.GetComponentInChildren<ShootingAbility>();
        playerShootingAbility.Set(weaponSettings.Weapons[0]);
    }

    public void OnGainNextLvl(int lvl)
    {
        if (lvl < weaponSettings.Weapons.Length)
            playerShootingAbility?.Set(weaponSettings.Weapons[lvl]);
    }

    public void Restart()
    {
        playerShootingAbility?.Set(weaponSettings.Weapons[0]);
    }
}