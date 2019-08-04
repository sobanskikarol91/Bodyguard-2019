using UnityEngine;

[CreateAssetMenu(fileName = "TimeObjectSpawnerSettings", menuName = "Spawning/TimeObjectSpawnerSettings")]
public class TimeObjectSpawnerSettings : ScriptableObject
{
    public TimeObjectSpawner[] Lvls { get => lvls; }
    [SerializeField] TimeObjectSpawner[] lvls;
}