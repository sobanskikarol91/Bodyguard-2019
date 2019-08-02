using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPool
{
    public readonly GameObject Prefab;
    public readonly int Id;

    private readonly Queue<GameObject> toSpawn = new Queue<GameObject>();
    private int spawnedObjectsAmount = 0;
    

    public ObjectPool(GameObject prefab)
    {
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

        if (returnConditions == null)
            Debug.LogError("No Return to Poll Conditions: " + newObject.name);

        Array.ForEach(returnConditions, r => r.Id = Id);

        ReturnToPool(newObject);
        spawnedObjectsAmount++;
    }

    public void ReturnToPool(GameObject returnObject)
    {
        returnObject.gameObject.SetActive(false);
        toSpawn.Enqueue(returnObject);
    }
}