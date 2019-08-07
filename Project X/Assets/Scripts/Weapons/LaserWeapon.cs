using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Laser")]
public class LaserWeapon : Weapon
{
    [SerializeField] float beamLength;

    protected override GameObject CreateBullet()
    {
        LineRenderer line = ObjectPoolManager.instance.Get(Bullet.gameObject).GetComponent<LineRenderer>();
        line.positionCount = 2;
        line.SetPosition(0, bulletSpawnPoint.position);
        line.SetPosition(1, bulletSpawnPoint.position + bulletSpawnPoint.right * beamLength);

        DamageOnRaycastHit damageOnRaycastHit = line.GetComponent<DamageOnRaycastHit>();
        damageOnRaycastHit.ChangeDamage(damage);
        damageOnRaycastHit?.CastRay(bulletSpawnPoint.position, bulletSpawnPoint.right, beamLength, damageObjects);
        return line.gameObject;
    }
}