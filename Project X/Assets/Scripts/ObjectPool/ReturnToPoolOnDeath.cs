public class ReturnToPoolOnDeath : ReturnToPool
{
    IDeath death;

    private void Awake()
    {
        death = GetComponent<IDeath>();
        death.Death += ReturnObjectToPool;
    }
}