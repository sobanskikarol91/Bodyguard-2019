using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPool
{
    public readonly GameObject Prefab;
    public readonly int Id;

    private readonly Queue<GameObject> toSpawn = new Queue<GameObject>();
    private int spawnedObjectsAmount = 0;
    private Transform poolHolder;

    public ObjectPool(GameObject prefab, Transform mainHolder)
    {
        poolHolder = new GameObject(prefab.name + "Pool").transform;
        poolHolder.SetParent(mainHolder);

        Id = prefab.GetInstanceID();
        Prefab = prefab;
    }

    public GameObject Get()
    {
        if (toSpawn.Count == 0)
            Add(1);

        GameObject poolObject = toSpawn.Dequeue();
        poolObject.gameObject.SetActive(true);

        return poolObject;
    }

    private void Add(int count)
    {
        GameObject newObject = GameObject.Instantiate(Prefab);
        newObject.name = newObject.name + spawnedObjectsAmount;
        ReturnToPool[] returnConditions = newObject.GetComponents<ReturnToPool>();
        newObject.transform.SetParent(poolHolder);

        if (returnConditions.Length == 0)
            AddPoolReference(newObject, ref returnConditions);

        Array.ForEach(returnConditions, r => r.Id = Id);

        ReturnToPool(newObject);
        spawnedObjectsAmount++;
    }

    private void AddPoolReference(GameObject newObject, ref ReturnToPool[] conditions)
    {
        conditions = new ReturnToPool[1];
        conditions[0] = newObject.AddComponent<ReturnToPool>();
    }

    public void ReturnToPool(GameObject returnObject)
    {
        returnObject.gameObject.SetActive(false);
        toSpawn.Enqueue(returnObject);
    }
}