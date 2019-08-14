using UnityEngine;

[CreateAssetMenu(fileName = "WeaponLvlSettings", menuName = "Level/Weapons")]
public class WeaponLvlSetting : ScriptableObject
{
    public WeaponSettings[] Weapons { get => weapons; }
    [SerializeField] WeaponSettings[] weapons;
}