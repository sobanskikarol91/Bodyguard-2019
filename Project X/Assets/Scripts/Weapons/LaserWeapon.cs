using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Laser")]
public class LaserWeapon : Weapon
{
    [SerializeField] float beamLength;

    protected override GameObject CreateBullet()
    {
        LineRenderer line = ObjectPoolManager.instance.Get(Bullet.gameObject).GetComponent<LineRenderer>();
        line.positionCount = 2;

        Vector3 start = Vector2.zero;
        Vector3 end = bulletSpawnPoint.right * beamLength;
        line.SetPosition(0, start);
        line.SetPosition(1, end);

        line.transform.SetParent(bulletSpawnPoint);
        line.transform.localPosition = Vector2.zero;
        line.transform.rotation = Quaternion.Euler(Vector3.zero);

        DamageOnRaycastHit damageOnRaycastHit = line.GetComponent<DamageOnRaycastHit>();


        damageOnRaycastHit?.CastRay(bulletSpawnPoint.position, end, beamLength, damageObjects);
        return line.gameObject;
    }
}