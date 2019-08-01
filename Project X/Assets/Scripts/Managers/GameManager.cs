using UnityEngine;

public class GameManager : MonoBehaviour, IRestart
{
    public static GameManager instance;
    public Player Player { get; private set; }
    public ScoreManager ScoreManager { get; private set; }
    public PlatformManager Platform { get => platform; }

    [SerializeField] Player playerPrefab;
    [SerializeField] PlatformManager platform;

    private SpawnManager spawnManager;
    private UIManager uiManager;


    private void Awake()
    {
        instance = this;
        GetReferences();
        InvokeMethods();    
    }

    private void GetReferences()
    {
        spawnManager = GetComponent<SpawnManager>();
        ScoreManager = GetComponent<ScoreManager>();
        uiManager = GetComponent<UIManager>();
        Player = ObjectPoolManager.instance.Get(playerPrefab.gameObject).GetComponent<Player>();
    }

    private void InvokeMethods()
    {
        Player.GetComponent<Health>().Death += GameOver;
    }
       
    public void GameOver()
    {
        Player.gameObject.SetActive(false);
        spawnManager.StopSpawning();
        spawnManager.enabled = false;
        uiManager.ShowGameOver();
    }

    public void Restart()
    {
        spawnManager.Restart();
        ObjectPoolManager.instance.Restart();
        ScoreManager.Reset();
        Player.gameObject.SetActive(true);
    }
}