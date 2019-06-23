public class Player : Character
{
    private Shooting shooting;

    protected override void Awake()
    {
        base.Awake();
        shooting = GetComponent<Shooting>();
    }
}