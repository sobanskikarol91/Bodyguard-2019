using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Laser")]
public class LaserWeapon : WeaponSettings
{
    [SerializeField] float beamLength;

    protected override GameObject CreateBullet()
    {
        LineRenderer line = ObjectPoolManager.instance.Get(Bullet.gameObject).GetComponent<LineRenderer>();
        line.positionCount = 2;

        line.transform.SetParent(bulletSpawnPoint);
        line.transform.localPosition = Vector2.zero;
        line.transform.localRotation = Quaternion.Euler(Vector3.zero);

        Vector3 start = Vector2.zero;
        Vector3 end = Vector2.right * beamLength;
        line.SetPosition(0, start);
        line.SetPosition(1, end);

        DamageOnRaycastHit damageOnRaycastHit = line.GetComponent<DamageOnRaycastHit>();

        damageOnRaycastHit?.CastRay(bulletSpawnPoint.position, bulletSpawnPoint.right * beamLength, beamLength, damageObjects);
        return line.gameObject;
    }
}