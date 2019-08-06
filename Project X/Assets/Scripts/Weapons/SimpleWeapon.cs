using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Simple")]
public class SimpleWeapon : Weapon
{
    protected override GameObject CreateBullet()
    {
        Transform bullet = ObjectPoolManager.instance.Get(Bullet.gameObject).transform;
        bullet.GetComponent<Damagable>()?.Init(damage, damageObjects);

        bullet.rotation = bulletSpawnPoint.rotation;
        bullet.transform.position = bulletSpawnPoint.position;
        return bullet.gameObject;
    }
}