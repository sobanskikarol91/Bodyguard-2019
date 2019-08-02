using UnityEngine;

public class SpawnManager : MonoBehaviour, IRestart, IDependsOnLvl
{
    [SerializeField] float radius = 3f;
    [SerializeField] bool spawnOnlyOneEnemy;
    [SerializeField] EnemySpawnSettings enemySpawnSettings;

    private Player player;
    private LvlEnemySpawn currentLvl;
    private float timeLeftToSpawn;
    private bool isSpawning = true;


    private void Start()
    {
        currentLvl = enemySpawnSettings.Lvls[0];
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
        int nr = Random.Range(0, currentLvl.Enemies.Length);
        return currentLvl.Enemies[nr];
    }

    public void StopSpawning()
    {
        isSpawning = true;
    }

    Vector2 GetRandomPosition()
    {
        Vector2 spawnPos = player.transform.position;
        return spawnPos + Random.insideUnitCircle.normalized * radius;
    }

    public void Restart()
    {
        isSpawning = true;
    }

    public void OnGainNextLvl(int lvl)
    {
        if (lvl < enemySpawnSettings.Lvls.Length)
            currentLvl = enemySpawnSettings.Lvls[lvl];
    }
}