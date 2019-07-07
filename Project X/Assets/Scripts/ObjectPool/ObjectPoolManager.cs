using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    Dictionary<int, ObjectPool> objectPools = new Dictionary<int, ObjectPool>();

    public static ObjectPoolManager instance;


    private void Awake()
    {
        instance = this;
    }

    public GameObject Get(GameObject instance)
    {
        ReturnToPool returnCondition = instance.GetComponent<ReturnToPool>();
        if (returnCondition == null)
            Debug.LogError("No Return to Poll Conditions: " + instance.name);

        int id = instance.GetInstanceID();
        ObjectPool pool;

        if (objectPools.TryGetValue(id, out pool))
            return pool.Get();
        else
        {
            pool = new ObjectPool(instance);
            CreateObjectPool(pool);
            return pool.Get();
        }
    }

    private void CreateObjectPool(ObjectPool pool)
    {
        objectPools.Add(pool.Id, pool);
        Debug.Log("Create pool " + pool.Id);
    }

    public void ReturnToPool(GameObject instance)
    {
        ObjectPool pool;
        int id = instance.GetComponent<ReturnToPool>().Id;

        if (!objectPools.TryGetValue(id, out pool))
        {
            CreateObjectPool(new ObjectPool(instance));
            objectPools.TryGetValue(id, out pool);
        }

        pool.ReturnToPool(instance);
    }
}