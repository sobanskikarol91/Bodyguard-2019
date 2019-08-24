using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour, IRestart
{
    public static ObjectPoolManager instance;

    private Dictionary<int, ObjectPool> objectPools = new Dictionary<int, ObjectPool>();
    private List<GameObject> spawnedObjects = new List<GameObject>();
    private Transform ObjectPoolsHolder;

    private void Awake()
    {
        ObjectPoolsHolder = new GameObject("ObjectPoolHolder").transform;
        instance = this;
    }

    public GameObject[] Get(GameObject instance, int amount)
    {
        GameObject[] gameobjects = new GameObject[amount];

        for (int i = 0; i < amount; i++)
            gameobjects[i] = Get(instance);

        return gameobjects;
    }

    public GameObject Get(GameObject instance)
    {
        ObjectPool pool;

        int id = instance.GetInstanceID();

        if (objectPools.TryGetValue(id, out pool) == false)
        {
            pool = new ObjectPool(instance, ObjectPoolsHolder);
            CreateObjectPool(pool);
        }

        GameObject poolObject = pool.Get();
        spawnedObjects.Add(poolObject);

        return poolObject;
    }

    private void CreateObjectPool(ObjectPool pool)
    {
        objectPools.Add(pool.Id, pool);
    }

    public void ReturnToPool(ReturnToPool returnCondition)
    {
        ObjectPool pool;

        if (!objectPools.TryGetValue(returnCondition.Id, out pool))
            pool = CreateNewPool(returnCondition);

        pool.ReturnToPool(returnCondition.gameObject);
        spawnedObjects.Remove(returnCondition.gameObject);
    }

    public void ReturnToPool(GameObject gameObject)
    {
        ReturnToPool returnCondition = gameObject.GetComponent<ReturnToPool>();

        if (returnCondition)
            ReturnToPool(returnCondition);
    }

    private ObjectPool CreateNewPool(ReturnToPool returnCondition)
    {
        ObjectPool pool = new ObjectPool(returnCondition.gameObject, ObjectPoolsHolder);
        CreateObjectPool(pool);
        objectPools.TryGetValue(returnCondition.Id, out pool);
        return pool;
    }

    public void OnRestart()
    {
        ReturnObjectsToPool();
    }

    private void ReturnObjectsToPool()
    {
        spawnedObjects.Select(s => s.GetComponent<ReturnToPool>()).ToList().ForEach(r => ReturnToPool(r));
    }
}