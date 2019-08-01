using System;
using UnityEngine;

public class SpawnManager : MonoBehaviour, IRestart
{
    [SerializeField] SpawnLvl[] lvls;
    [SerializeField] float radius = 3f;
    [SerializeField] bool spawnOnlyOneEnemy;

    private Player player;
    private SpawnLvl currentLvl;
    private float timeLeftToSpawn;
    private bool isSpawning = true;


    private void Start()
    {
        currentLvl = lvls[0];
        player = GameManager.instance.Player;
        ResetSpawnTime();
    }

    void Update()
    {
        if (isSpawning)
            DecreaseSpawnTime();
    }

    private void DecreaseSpawnTime()
    {
        timeLeftToSpawn -= Time.deltaTime;

        if (timeLeftToSpawn <= 0)
            Spawn();
    }

    private void Spawn()
    {
        Debug.Log("Spawn");
        ShowNewEnemy();
        ResetSpawnTime();

        if (spawnOnlyOneEnemy) timeLeftToSpawn = 1000;
    }

    private void ShowNewEnemy()
    {
        Enemy random = GetRandomEnemy();
        Transform enemy = ObjectPoolManager.instance.Get(random.gameObject).transform;
        enemy.position = GetRandomPosition();
    }

    private void ResetSpawnTime()
    {
        timeLeftToSpawn = currentLvl.SpawTime;
    }

    Enemy GetRandomEnemy()
    {
        int nr = UnityEngine.Random.Range(0, currentLvl.Enemies.Length);
        return currentLvl.Enemies[nr];
    }

    public void StopSpawning()
    {
        isSpawning = true;
    }

    Vector2 GetRandomPosition()
    {
        Vector2 spawnPos = player.transform.position;
        return spawnPos + UnityEngine.Random.insideUnitCircle.normalized * radius;
    }

    [Serializable]
    public class SpawnLvl
    {
        public float SpawTime { get { return spawnTime; } }
        public Enemy[] Enemies { get { return enemies; } }

        [SerializeField] float spawnTime;
        [SerializeField] Enemy[] enemies;
    }

    [Serializable]
    public class SpawnEnemy
    {
        [SerializeField] Enemy enemy;
        [SerializeField, Range(0, 1)] float percantage;
    }

    public void Restart()
    {
        isSpawning = true;
    }
}