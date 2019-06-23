public class Player : Character
{
    Shooting shooting;

    protected override void Awake()
    {
        base.Awake();
        shooting = GetComponent<Shooting>();
    }
}