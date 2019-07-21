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
    }

    private void InvokeMethods()
    {
        Player = ObjectPoolManager.instance.Get(playerPrefab.gameObject).GetComponent<Player>();
        Player.GetComponent<Health>().Death += GameOver;
    }
       
    public void GameOver()
    {
        Player.gameObject.SetActive(false);
        spawnManager.enabled = false;
        Invoke("Reset", 1f);
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