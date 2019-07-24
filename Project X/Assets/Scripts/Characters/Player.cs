public class Player : Character
{
   private PlayerInput input;

    protected void Awake()
    {
        Type = ObjectType.Player;
        input = GameManager.instance.Platform.GetPlayerInputDependsOnPlatform();
        input.Init();
    }

    private void Update()
    {
        input.Execute();
    }
}