public class Player : Character
{
    protected override void Awake()
    {
        base.Awake();
        Type = ObjectType.Player;
    }
}