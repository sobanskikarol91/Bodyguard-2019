using UnityEngine;


public abstract class Weapon : ScriptableObject
{
    public Damagable Bullet { get { return bullet; } }
    public float RefireRate { get { return refireRate; } }

    [SerializeField] Damagable bullet;
    [SerializeField] float refireRate = 0.1f;
    [SerializeField] protected ObjectType[] damageObjects;
    [SerializeField] protected float damage;

    protected Transform bulletSpawnPoint;

    public virtual void Init(Transform bulletSpawnPoint)
    {
        this.bulletSpawnPoint = bulletSpawnPoint;
    }

    public abstract void Shoot();
}
