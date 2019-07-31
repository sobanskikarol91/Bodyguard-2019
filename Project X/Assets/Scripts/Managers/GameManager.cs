using UnityEngine;

public class GameManager : MonoBehaviour
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
        spawnManager.enabled = false;
        uiManager.ShowGameOver();
    }

    private void Reset()
    {
        Player.gameObject.SetActive(true);
        spawnManager.enabled = true;
        Player.GetComponent<Collider2D>().enabled = false;
        ScoreManager.Reset();
        Invoke("GoodModeOff", 1f);
    }

    void GoodModeOff()
    {
        Player.GetComponent<Collider2D>().enabled = true;
    }
}