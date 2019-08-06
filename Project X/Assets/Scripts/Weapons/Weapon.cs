using UnityEngine;


public abstract class Weapon : ScriptableObject
{
    public Damagable Bullet { get { return bullet; } }
    public float RefireRate { get { return refireRate; } }


    [SerializeField] Damagable bullet;
    [SerializeField] float refireRate = 0.1f;
    [SerializeField] protected float damage;
    [SerializeField] protected ObjectType[] damageObjects;


    protected Transform bulletSpawnPoint;

    public virtual void Init(Transform bulletSpawnPoint)
    {
        this.bulletSpawnPoint = bulletSpawnPoint;
    }

    public abstract void Shoot();
}
