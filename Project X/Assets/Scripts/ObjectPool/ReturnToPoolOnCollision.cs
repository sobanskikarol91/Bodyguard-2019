public class ReturnToPoolOnCollision : ReturnToPool
{
    private DoDamageOnCollision damageOnCollision;

    protected void Awake()
    {
        damageOnCollision = GetComponent<DoDamageOnCollision>();
    }

    private void OnEnable()
    {
        if (damageOnCollision != null)
            damageOnCollision.DoDamage += ReturnOnCollision;
    }

    private void OnDisable()
    {
        if (damageOnCollision != null)
            damageOnCollision.DoDamage -= ReturnOnCollision;
    }

    private void ReturnOnCollision()
    {
        damageOnCollision.DoDamage -= ReturnOnCollision;
        ObjectPoolManager.instance.ReturnToPool(this);
    }
}