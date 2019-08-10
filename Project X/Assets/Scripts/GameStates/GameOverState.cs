public class GameOverState : IState
{
    private UIManager uiManager;
    private LightManager lightManager;

    public GameOverState()
    {
        uiManager = GameManager.instance.GetComponent<UIManager>();
        lightManager = GameManager.instance.GetComponent<LightManager>();
    }

    public void Enter()
    {
        SlowMotion.instance.RunEffect(0.2f, 2.3f, uiManager.ShowGameOver);
        CameraZoom.instance.ZoomOutAndIn(0.48f, 4f);
        lightManager.DecreaseSpotAngle(55f, 4.6f);
    }

    public void Execute() { }
    public void Exit() { }
}