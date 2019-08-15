using UnityEngine;

[CreateAssetMenu(fileName = "GameWeapons", menuName = "Level/GameWeapons")]
public class GameWeaponsSettings : ScriptableObject
{
    public LevelWeapon[] Weapons { get => weapons; }
    [SerializeField] LevelWeapon[] weapons;
}