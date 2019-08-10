using System;
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
    private IRestart[] restartObjects;

    private State gameOverState;

    private void Awake()
    {
        instance = this;
        GetReferences();
        SubscribeEvents();
        InitObjects();
    }

    private void InitObjects()
    {
        Action actions = delegate { };
        actions += spawnManager.StopSpawning;
        actions += uiManager.ShowGameOver;
        gameOverState = new GameOverState(actions);
    }

    private void GetReferences()
    {
        restartObjects = GetComponents<IRestart>();
        spawnManager = GetComponent<SpawnManager>();
        ScoreManager = GetComponent<ScoreManager>();
        uiManager = GetComponent<UIManager>();
        Player = ObjectPoolManager.instance.Get(playerPrefab.gameObject).GetComponent<Player>();
    }

    private void SubscribeEvents()
    {
        Player.GetComponent<HealthAbility>().Death += GameOver;
    }

    public void GameOver()
    {
        gameOverState.Start();
    }

    public void Restart()
    {
        Array.ForEach(restartObjects, r => r.Restart());
        Player.gameObject.SetActive(true);
        Player.transform.position = Vector3.zero;
    }
}