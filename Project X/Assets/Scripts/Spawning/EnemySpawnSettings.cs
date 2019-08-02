using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnSettings", menuName = "Spawning/EnemySpawnSettings")]
public class EnemySpawnSettings : ScriptableObject
{
    public LvlEnemySpawn[] Lvls { get => lvls; }
    [SerializeField] LvlEnemySpawn[] lvls;
}