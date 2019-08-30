public class GameOverState : IState
{
    private UIManager uiManager;
    private LightManager lightManager;
    private SpawnManager spawnManager;
    private float duration = 0.85f;

    public GameOverState()
    {
        spawnManager = GameManager.instance.GetComponent<SpawnManager>();
        uiManager = GameManager.instance.GetComponent<UIManager>();
        lightManager = GameManager.instance.GetComponent<LightManager>();
    }

    public void Enter()
    {
        PlayEnemiesWinAnimation();
        lightManager.DecreaseSpotAngle(55f, duration);
        SlowMotion.instance.RunEffect(0.2f, duration, OnEndSlowMontion);
    }

    private void PlayEnemiesWinAnimation()
    {
        spawnManager.spawnedEnemies.ForEach(s => s.GetComponent<IGameOver>().OnGameOver());
    }

    void OnEndSlowMontion()
    {
        CameraZoom.instance.ZoomIn(duration, 2f);
        uiManager.ShowGameOver();
    }

    public void Execute() { }
    public void Exit() { }
}