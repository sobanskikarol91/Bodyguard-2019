public class GameOverState : IState
{
    private UIManager uiManager;
    private LightManager lightManager;
    private float duration = 0.8f;

    public GameOverState()
    {
        uiManager = GameManager.instance.GetComponent<UIManager>();
        lightManager = GameManager.instance.GetComponent<LightManager>();
    }

    public void Enter()
    {
        lightManager.DecreaseSpotAngle(55f, duration);
        SlowMotion.instance.RunEffect(0.2f, duration, OnEndSlowMontion);
    }

    void OnEndSlowMontion()
    {
        CameraZoom.instance.ZoomIn(duration, 2f);
        uiManager.ShowGameOver();
    }

    public void Execute() { }
    public void Exit() { }
}