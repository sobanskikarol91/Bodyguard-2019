public class Player : Character
{
    PlayerInput input;

    protected void Awake()
    {
        Type = ObjectType.Player;
        input = GameManager.instance.Platform.GetPlayerInputDependsOnPlatform();
        input.Init();

        GetComponent<RotationAbility>().Input = input.Rotating;
    }

    private void Update()
    {
        input.Execute();
    }
}