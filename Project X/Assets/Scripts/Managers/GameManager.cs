using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player Player { get { return player; } }

    [SerializeField] Player player;

    public ScoreManager ScoreManager { get; private set; }
    public EnemySpawner enemySpawner;

    private void Awake()
    {
        enemySpawner = GetComponent<EnemySpawner>();
        ScoreManager = GetComponent<ScoreManager>();
        player.GetComponent<Health>().Death += GameOver;
        instance = this;
    }

    public void GameOver()
    {
        player.gameObject.SetActive(false);
        enemySpawner.enabled = false;
        Invoke("Reset", 1f);
    }

    private void Reset()
    {
        player.gameObject.SetActive(true);
        enemySpawner.enabled = true;
        player.GetComponent<Collider2D>().enabled = false;
        ScoreManager.Reset();
        Invoke("GoodModeOff", 1f);
    }

    void GoodModeOff()
    {
        player.GetComponent<Collider2D>().enabled = true;
    }
}