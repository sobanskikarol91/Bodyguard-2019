using System;

public class ExecutingGame : IState
{
    private SpawnManager spawnManager;


    public ExecutingGame (SpawnManager spawnManager)
    {
        this.spawnManager = spawnManager;
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