using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] SpawnLvl[] lvls;
    [SerializeField] float radius = 3f; 

    private Player player;
    private int lvlNr = 0;
    private float timeLeftToSpawn;


    private void Awake()
    {
        player = GameManager.instance.Player;
        ResetSpawnTime();
    }

    void Update()
    {
        timeLeftToSpawn -= Time.deltaTime;

        if (timeLeftToSpawn <= 0)
            Spawn();
    }

    private void Spawn()
    {
        ShowNewEnemy();
        ResetSpawnTime();
    }

    private void ShowNewEnemy()
    {
        Transform enemy = Instantiate(lvls[lvlNr].Enemies[0]).transform;
        enemy.position = GetRandomPosition();
    }

    private void ResetSpawnTime()
    {
        timeLeftToSpawn = lvls[lvlNr].SpawTime;
    }

    Vector2 GetRandomPosition()
    {
        Vector2 spawnPos = player.transform.position;
        return spawnPos + UnityEngine.Random.insideUnitCircle.normalized* radius;
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
}
