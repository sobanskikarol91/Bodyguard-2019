public class Player : Character
{
    protected override void Awake()
    {
        base.Awake();
        type = ObjectType.Player;
    }
}