using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class LvlEnemySpawn
{
    public float SpawTime { get { return spawnTime; } }
    public EnemyPercentageSpawn[] Enemies { get { return enemies; } }
    private Dictionary<float, Enemy> percantageEnemies = new Dictionary<float, Enemy>();
    [SerializeField] float spawnTime = 1f;
    [SerializeField] EnemyPercentageSpawn[] enemies;

    public Enemy GetRandomEnemy()
    {
        if (percantageEnemies.Count == 0)
            CreateDictionary();

        float percantage = UnityEngine.Random.value;
        return GetEnemyFromDictionary(percantage);
    }

    void CreateDictionary()
    {
        float totalPercantage = 0;
        Array.ForEach(Enemies, e => totalPercantage += e.Percentage);

        float previousEnemyPercantage = 0;

        for (int i = 0; i < Enemies.Length; i++)
        {
            EnemyPercentageSpawn enemy = Enemies[i];
            float percantage = enemy.Percentage / totalPercantage;
            previousEnemyPercantage += percantage;
            percantageEnemies.Add(previousEnemyPercantage, enemy.Prefab);
        }
    }

    Enemy GetEnemyFromDictionary(float percantage)
    {
        if (percantageEnemies.Count == 1) return percantageEnemies.First().Value;

        Enemy result = null;

        for (int i = 0; i < percantageEnemies.Count - 1; i++)
        {
            if (percantage >= percantageEnemies.ElementAt(i).Key && percantage <= percantageEnemies.ElementAt(i + 1).Key)
                return percantageEnemies.ElementAt(i).Value;
            else if (i == percantageEnemies.Count - 2)
                return percantageEnemies.ElementAt(i+1).Value;
        }

        return result;
    }
}

[Serializable]
public class EnemyPercentageSpawn
{
    public float Percentage { get { return percentage; } }
    public Enemy Prefab { get { return prefab; } }

    [Range(0, 1), SerializeField] float percentage;
    [SerializeField] Enemy prefab;
}