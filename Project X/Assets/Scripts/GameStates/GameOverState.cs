public class GameOverState : IState
{
    private UIManager uiManager;

    public GameOverState()
    {
        uiManager = GameManager.instance.GetComponent<UIManager>();
    }

    public void Enter()
    {
        SlowMotion.instance.RunEffect(0.2f, 1f, uiManager.ShowGameOver);
        CameraZoom.instance.ZoomOutAndIn(0.4f, 1f);
    }

    public void Execute() { }
    public void Exit() { }
}