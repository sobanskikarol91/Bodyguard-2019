using UnityEngine;

[CreateAssetMenu(fileName = "WeaponLvlSettings", menuName = "Level/Weapons")]
public class WeaponLvlSetting : ScriptableObject
{
    public Weapon[] Weapons { get => weapons; }
    [SerializeField] Weapon[] weapons;
}