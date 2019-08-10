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
    private StateMachine stateMachine = new StateMachine();
    private IState gameOver, reset;

    private void Awake()
    {
        instance = this;
        GetReferences();
        SubscribeEvents();
        InitStates();
    }

    private void Update()
    {
        stateMachine.Execute();
    }

    private void InitStates()
    {
        Action actions = delegate { };
        actions += spawnManager.StopSpawning;
        actions += uiManager.ShowGameOver;
        gameOver = new GameOverState(actions);
        reset = new ResetState();
    }

    private void GetReferences()
    {
        spawnManager = GetComponent<SpawnManager>();
        ScoreManager = GetComponent<ScoreManager>();
        uiManager = GetComponent<UIManager>();
        Player = ObjectPoolManager.instance.Get(playerPrefab.gameObject).GetComponent<Player>();
    }

    private void SubscribeEvents()
    {
        Player.GetComponent<HealthAbility>().Death += GameOver;
    }

    private void GameOver()
    {
        stateMachine.ChangeState(gameOver);
    }

    public void Reset()
    {
        stateMachine.ChangeState(reset);
    }
}