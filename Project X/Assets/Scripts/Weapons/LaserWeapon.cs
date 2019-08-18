using UnityEngine;

public class LaserWeapon : Weapon
{
    [SerializeField] float beamLength;

    protected override GameObject Attack()
    {
        LineRenderer line = ObjectPoolManager.instance.Get(Bullet.gameObject).GetComponent<LineRenderer>();
        line.positionCount = 2;

        line.transform.SetParent(BulletSpawnPoint);
        line.transform.localPosition = Vector2.zero;
        line.transform.localRotation = Quaternion.Euler(Vector3.zero);

        Vector3 start = Vector2.zero;
        Vector3 end = Vector2.right * beamLength;
        line.SetPosition(0, start);
        line.SetPosition(1, end);

        DamageOnRaycastHit damageOnRaycastHit = line.GetComponent<DamageOnRaycastHit>();

        damageOnRaycastHit?.CastRay(BulletSpawnPoint.position, BulletSpawnPoint.right * beamLength, beamLength);
        return line.gameObject;
    }
}