using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ObjectPool
{
    public readonly GameObject Prefab;
    public readonly int Id;

    private Queue<GameObject> instances = new Queue<GameObject>();


    public ObjectPool(GameObject prefab, int id)
    {
        Id = id;
        Prefab = prefab;

        ObjectPoolId prefabId = prefab.GetComponent<ObjectPoolId>();

        if (!prefabId)
            prefab.AddComponent<ObjectPoolId>();

        prefabId.id = Id;
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

