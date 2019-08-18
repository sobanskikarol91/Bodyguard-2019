using UnityEngine;

public class Pistol : Weapon
{
    protected override GameObject Attack()
    {
        Transform bullet = ObjectPoolManager.instance.Get(Bullet.gameObject).transform;
        bullet.rotation =  BulletSpawnPoint.rotation;
        bullet.transform.position = BulletSpawnPoint.position;
        return bullet.gameObject;
    }
}