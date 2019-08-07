using UnityEngine;

public class WeaponLvlManager : MonoBehaviour, IDependsOnLvl, IRestart
{
    [SerializeField] WeaponLvlSetting weaponSettings;
    private ShootingAbility playerShootingAbility;

    private void Start()
    {
        playerShootingAbility = GameManager.instance.Player.GetComponent<ShootingAbility>();
    }

    public void OnGainNextLvl(int lvl)
    {
        Debug.Log("Gain lvl " + lvl);
        if (lvl < weaponSettings.Weapons.Length)
            playerShootingAbility?.Set(weaponSettings.Weapons[lvl]);
    }

    public void Restart()
    {
        playerShootingAbility?.Set(weaponSettings.Weapons[0]);
    }
}