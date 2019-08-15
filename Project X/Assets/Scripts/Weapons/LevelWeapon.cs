using UnityEngine;

[CreateAssetMenu(fileName = "LevelWeapon", menuName = "Level/Weapon")]
public class LevelWeapon : ScriptableObject
{
    public GameObject Model { get => model; }
    [SerializeField] GameObject model;
}
