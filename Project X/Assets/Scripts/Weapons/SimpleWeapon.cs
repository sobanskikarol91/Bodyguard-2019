using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Simple")]
public class SimpleWeapon : WeaponSettings
{
    protected override GameObject CreateBullet()
    {
        Transform bullet = ObjectPoolManager.instance.Get(Bullet.gameObject).transform;
        bullet.rotation =  bulletSpawnPoint.rotation;
        bullet.transform.position = bulletSpawnPoint.position;
        return bullet.gameObject;
    }
}