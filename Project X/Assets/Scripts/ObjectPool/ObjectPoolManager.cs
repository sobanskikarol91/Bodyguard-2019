using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour, IRestart
{
    public static ObjectPoolManager instance;

    private Dictionary<int, ObjectPool> objectPools = new Dictionary<int, ObjectPool>();
    private List<GameObject> spawnedObjects = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    public GameObject Get(GameObject instance)
    {
        CheckIsThereAnyConditionAttached(instance);

        ObjectPool pool;

        int id = instance.GetInstanceID();

        if (objectPools.TryGetValue(id, out pool) == false)
        {
            pool = new ObjectPool(instance);
            CreateObjectPool(pool);
        }

        GameObject poolObject = pool.Get();
        spawnedObjects.Add(poolObject);

        return poolObject;
    }

    private static void CheckIsThereAnyConditionAttached(GameObject instance)
    {
        ReturnToPool returnCondition = instance.GetComponent<ReturnToPool>();

        if (returnCondition == null)
            Debug.LogError("No Return to Poll Conditions: " + instance.name);
    }

    public GameObject[] Get(GameObject instance, int amount)
    {
        GameObject[] gameobjects = new GameObject[amount];

        for (int i = 0; i < amount; i++)
            gameobjects[i] = Get(instance);

        return gameobjects;
    }

    private void CreateObjectPool(ObjectPool pool)
    {
        objectPools.Add(pool.Id, pool);
    }

    public void ReturnToPool(ReturnToPool returnCondition)
    {
        ObjectPool pool;

        if (!objectPools.TryGetValue(returnCondition.Id, out pool))
        {
            CreateObjectPool(new ObjectPool(returnCondition.gameObject));
            objectPools.TryGetValue(returnCondition.Id, out pool);
        }

        pool.ReturnToPool(returnCondition.gameObject);
        spawnedObjects.Remove(returnCondition.gameObject);
    }

    public void Restart()
    {
        ReturnObjectsToPool();
    }

    private void ReturnObjectsToPool()
    {
        spawnedObjects.Select(s => s.GetComponent<ReturnToPool>()).ToList().ForEach(r => ReturnToPool(r));
    }
}