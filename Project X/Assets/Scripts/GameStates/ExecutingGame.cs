public class ExecutingGame : IState
{
    private SpawnManager spawnManager;

    public ExecutingGame ()
    {
        spawnManager = GameManager.instance.GetComponent<SpawnManager>();
    }

    public void Enter()
    {
    
    }

    public void Execute()
    {
        spawnManager.Execute();
    }

    public void Exit()
    {

    }
}