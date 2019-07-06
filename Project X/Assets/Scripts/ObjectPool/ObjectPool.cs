using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ObjectPool
{
    public readonly GameObject Prefab;
    public readonly int Id;
    static int poolsCount = 0;

    private Queue<GameObject> instances = new Queue<GameObject>();


    public ObjectPool(GameObject prefab)
    {
        Id = poolsCount;
        Prefab = prefab;

        ObjectPoolId prefabId = prefab.GetComponent<ObjectPoolId>();

        if (!prefabId)
            prefabId = prefab.AddComponent<ObjectPoolId>();

        prefabId.id = Id;
        poolsCount++;
    }

    public GameObject Get()
    {
        if (instances.Count == 0)
            Add(1);

        GameObject poolObject = instances.Dequeue();
        poolObject.gameObject.SetActive(true);

        return poolObject;
    }

    private void Add(int count)
    {
        GameObject newObject = GameObject.Instantiate(Prefab);
        ReturnToPool(newObject);
    }

    public void ReturnToPool(GameObject returnObject)
    {
        Debug.Log("return to pool: " + returnObject.name);
        returnObject.gameObject.SetActive(false);
        instances.Enqueue(returnObject);
    }
}

