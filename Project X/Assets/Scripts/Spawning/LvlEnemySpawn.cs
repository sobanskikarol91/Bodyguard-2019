using System;
using UnityEngine;

[Serializable]
public class LvlEnemySpawn 
{
    public float SpawTime { get { return spawnTime; } }
    public Enemy[] Enemies { get { return enemies; } }

    [SerializeField] float spawnTime;
    [SerializeField] Enemy[] enemies;
}