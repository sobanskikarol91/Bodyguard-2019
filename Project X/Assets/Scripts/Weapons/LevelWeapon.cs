using UnityEngine;

[CreateAssetMenu(fileName = "LevelWeapon", menuName = "Level/Weapon")]
public class LevelWeapon : ScriptableObject
{
    public GameObject Model  => model;
    [SerializeField] GameObject model;

    public GameObject Bullet => bullet;
    [SerializeField] GameObject bullet;

    [Header("Effects")]
    [SerializeField] ShootingEffect[] bulletEffects;
    [SerializeField] ShootingEffect[] characterEffects;
}