using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponLvlManager : MonoBehaviour, IDependsOnLvl
{
    [SerializeField] WeaponLvlSetting weaponSettings;
    private ShootingAbility playerShootingAbility;
    
    private void Start()
    {
        playerShootingAbility = GameManager.instance.Player.GetComponent<ShootingAbility>();
    }

    public void OnGainNextLvl(int lvl)
    {
        playerShootingAbility?.Set(weaponSettings.Weapons[lvl]);
    }
}