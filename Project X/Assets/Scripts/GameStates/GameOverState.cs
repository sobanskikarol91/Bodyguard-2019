using System;

public class GameOverState : IState
{
    Action ExitActions;

    public GameOverState(Action ExitActions)
    {
        this.ExitActions = ExitActions;
    }

    public void Enter()
    {
        SlowMotion.instance.RunEffect(0.2f, 1, ExitActions);
    }

    public void Execute()
    {

    }

    public void Exit()
    {
      
    }
}