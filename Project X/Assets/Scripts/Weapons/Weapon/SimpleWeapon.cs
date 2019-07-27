using UnityEngine;


[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Simple")]
public class SimpleWeapon : Weapon
{
    public override void Shoot(Transform transform)
    {
        Transform bullet = ObjectPoolManager.instance.Get(Bullet.gameObject).transform;
        bullet.GetComponent<Damagable>()?.Init(damage, damageObjects);

        bullet.rotation = transform.rotation;
        bullet.transform.position = transform.position;
    }
}