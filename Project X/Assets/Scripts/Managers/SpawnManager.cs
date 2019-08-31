using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour, IRestart, IDependsOnLvl
{
    [SerializeField] float radius = 3f;
    [SerializeField] bool spawnOnlyOneEnemy;
    [SerializeField] TimeObjectSpawnerSettings enemySpawnSettings;
    public List<Transform> spawnedEnemies { get; }  = new List<Transform>();

    private Player player;
    private TimeObjectSpawner currentLvl;
    private float timeLeftToSpawn;


    private void Start()
    {
        OnRestart();
        player = GameManager.instance.Player;
    }


    public void Execute()
    {
        timeLeftToSpawn -= Time.deltaTime;

        if (timeLeftToSpawn <= 0)
            Spawn();
    }

    private void Spawn()
    {
        CreateObject();
        ResetSpawnTime();

        if (spawnOnlyOneEnemy) timeLeftToSpawn = 1000;
    }

    private void CreateObject()
    {
        GameObject random = currentLvl.GetRandomObject();
        Transform enemy = ObjectPoolManager.instance.Get(random.gameObject).transform;
        enemy.position = GetRandomPosition();

        AddEnemyToList(enemy);
    }

    private void AddEnemyToList(Transform enemy)
    {
        if (spawnedEnemies.Contains(enemy))
            return;
        else
            spawnedEnemies.Add(enemy);
    }

    private void ResetSpawnTime()
    {
        timeLeftToSpawn = currentLvl.SpawTime;
    }

    Vector2 GetRandomPosition()
    {
        Vector2 spawnPos = player.transform.position;
        return spawnPos + UnityEngine.Random.insideUnitCircle.normalized * radius;
    }

    public void OnRestart()
    {
        spawnedEnemies.Clear();
        currentLvl = enemySpawnSettings.Lvls[0];
        ResetSpawnTime();
    }

    public void OnGainNextLvl(int lvl)
    {
        if (lvl < enemySpawnSettings.Lvls.Length)
            currentLvl = enemySpawnSettings.Lvls[lvl];
    }
}