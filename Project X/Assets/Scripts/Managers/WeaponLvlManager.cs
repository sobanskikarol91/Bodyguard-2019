using UnityEngine;

public class WeaponLvlManager : MonoBehaviour, IDependsOnLvl, IRestart
{
    [SerializeField] GameWeaponsSettings weaponSettings;
    private ShootingAbility playerShootingAbility;

    private void Start()
    {
        playerShootingAbility = GameManager.instance.Player.GetComponentInChildren<ShootingAbility>();
        Restart();
    }

    public void OnGainNextLvl(int lvl)
    {
        if (lvl < weaponSettings.Weapons.Length)
            playerShootingAbility?.Set(weaponSettings.Weapons[lvl].Model);
    }

    public void Restart()
    {
        playerShootingAbility?.Set(weaponSettings.Weapons[0].Model);
    }
}