using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/MultipleBullets")]
public class MultipleBulletWeapon : Weapon
{
    [SerializeField, Tooltip("Angle between bullets")] int amount;
    [SerializeField, Tooltip("Angle between bullets")] float angle;


    public override void Shoot(Transform transform)
    {
        GameObject[] bullets = ObjectPoolManager.instance.Get(Bullet.gameObject, amount);

        for (int i = 0; i < amount; i++)
        {
            float angleZ = GetAngle(transform, i);
            Vector3 rotation = new Vector3(0, 0, angleZ);
            bullets[i].transform.rotation = Quaternion.Euler(rotation);
            bullets[i].transform.position = transform.position;
        }
    }

    float GetAngle(Transform player, int bulletNr)
    {
        float playerRotation = player.rotation.eulerAngles.z;
        float firstBulletRotation = playerRotation - angle * amount / 2;
        return firstBulletRotation += bulletNr * angle;
    }
}