using UnityEngine;

public class SpawnManager : MonoBehaviour, IRestart, IDependsOnLvl
{
    [SerializeField] float radius = 3f;
    [SerializeField] bool spawnOnlyOneEnemy;
    [SerializeField] TimeObjectSpawnerSettings enemySpawnSettings;

    private Player player;
    private TimeObjectSpawner currentLvl;
    private float timeLeftToSpawn;


    private void Start()
    {
        Restart();
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
        ShowNewEnemy();
        ResetSpawnTime();

        if (spawnOnlyOneEnemy) timeLeftToSpawn = 1000;
    }

    private void ShowNewEnemy()
    {
        GameObject random = currentLvl.GetRandomObject();
        Transform enemy = ObjectPoolManager.instance.Get(random.gameObject).transform;
        enemy.position = GetRandomPosition();
    }

    private void ResetSpawnTime()
    {
        timeLeftToSpawn = currentLvl.SpawTime;
    }

    Vector2 GetRandomPosition()
    {
        Vector2 spawnPos = player.transform.position;
        return spawnPos + Random.insideUnitCircle.normalized * radius;
    }

    public void Restart()
    {
        currentLvl = enemySpawnSettings.Lvls[0];
        ResetSpawnTime();
    }

    public void OnGainNextLvl(int lvl)
    {
        if (lvl < enemySpawnSettings.Lvls.Length)
            currentLvl = enemySpawnSettings.Lvls[lvl];
    }
}