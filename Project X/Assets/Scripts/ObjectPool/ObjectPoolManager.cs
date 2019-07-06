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
        ObjectPoolId objectPoolId = instance.GetComponent<ObjectPoolId>();

        if (!objectPoolId)
            CreateObjectPool(new ObjectPool(instance));

        int id = instance.GetComponent<ObjectPoolId>().id;
        ObjectPool pool;

        if (objectPools.TryGetValue(id, out pool))
            return pool.Get();
        else
            CreateObjectPool(new ObjectPool(instance));

        return Get(instance);
    }

    private void CreateObjectPool(ObjectPool pool)
    {
        Debug.Log("Create pool" + pool.Id);
        objectPools.Add(pool.Id, pool);
    }

    public void ReturnToPool(GameObject instance)
    {
        ObjectPool pool;
        int id = instance.GetComponent<ObjectPoolId>().id;

        if (!objectPools.TryGetValue(id, out pool))
        {
            CreateObjectPool(new ObjectPool(instance));
            objectPools.TryGetValue(id, out pool);
        }

        pool.ReturnToPool(instance);
    }
}