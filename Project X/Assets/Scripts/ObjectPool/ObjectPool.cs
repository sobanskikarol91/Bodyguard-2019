using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPool
{
    public readonly GameObject Prefab;
    public readonly int Id;

    private readonly Queue<GameObject> instances = new Queue<GameObject>();


    public ObjectPool(GameObject prefab)
    {
        Id = prefab.GetInstanceID();
        Prefab = prefab;
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
        ReturnToPool[] returnConditions = newObject.GetComponents<ReturnToPool>();

        if (returnConditions == null)
            Debug.LogError("No Return to Poll Conditions: " + newObject.name);

        Array.ForEach(returnConditions, r => r.Id = Id);

        ReturnToPool(newObject);
    }

    public void ReturnToPool(GameObject returnObject)
    {
        returnObject.gameObject.SetActive(false);
        instances.Enqueue(returnObject);
    }
}

