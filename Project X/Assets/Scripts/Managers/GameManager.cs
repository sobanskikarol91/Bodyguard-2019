using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player Player { get; private set; }
    public ScoreManager ScoreManager { get; private set; }
    public PlatformManager Platform { get => platform; }
    public LevelManager LevelManager;

    [SerializeField] Player playerPrefab;
    [SerializeField] PlatformManager platform;

    private StateMachine stateMachine = new StateMachine();
    private IState gameOver, reset, executingGame;


    private void Awake()
    {
        instance = this;
        GetReferences();
        SubscribeEvents();
        InitStates();
        ChangeToExecutingGame();
    }

    private void Update()
    {
        stateMachine.Execute();
    }

    private void InitStates()
    {
        gameOver = new GameOverState();
        reset = new ResetState(ChangeToExecutingGame);
        executingGame = new ExecutingGame();
    }

    private void GetReferences()
    {
        LevelManager = GetComponent<LevelManager>();
        ScoreManager = GetComponent<ScoreManager>();
        Player = ObjectPoolManager.instance.Get(playerPrefab.gameObject).GetComponent<Player>();
    }

    private void SubscribeEvents()
    {
        Player.GetComponent<HealthAbility>().Death += ChangeToGameOver;
    }

    private void ChangeToGameOver()
    {
        stateMachine.ChangeState(gameOver);
    }

    public void ChangeToReset()
    {
        stateMachine.ChangeState(reset);
    }

    private void ChangeToExecutingGame()
    {
        stateMachine.ChangeState(executingGame);
    }
}