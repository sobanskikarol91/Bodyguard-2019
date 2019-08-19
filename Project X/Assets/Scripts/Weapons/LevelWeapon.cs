using UnityEngine;

[CreateAssetMenu(fileName = "LevelWeapon", menuName = "Level/Weapon")]
public class LevelWeapon : ScriptableObject
{
    public GameObject Model => model;
    [SerializeField] GameObject model;

    public GameObject Bullet => bullet;
    [SerializeField] GameObject bullet;

    public ShootingEffect[] BulletEffects => bulletEffects;
    [SerializeField] ShootingEffect[] bulletEffects;

    public ShootingEffect[] WeaponEffects => weaponEffects;
    [SerializeField] ShootingEffect[] weaponEffects;
}