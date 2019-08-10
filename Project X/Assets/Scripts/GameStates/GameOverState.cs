using System;

public class GameOverState : IState
{
    UIManager uiManager;
    public GameOverState()
    {
        uiManager = GameManager.instance.GetComponent<UIManager>();
    }

    public void Enter()
    {
        SlowMotion.instance.RunEffect(0.2f, 1, uiManager.ShowGameOver);
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }
}