using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public abstract class ObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T prefab;

    public static ObjectPool<T> instance { get; private set; }

    private Queue<T> gameobjects = new Queue<T>();


    private void Awake()
    {
        instance = this;
    }

    public T Get()
    {
        if (gameobjects.Count == 0)
            Add(1);
        T poolObject = gameobjects.Dequeue();
        poolObject.gameObject.SetActive(true);

        return poolObject;
    }

    private void Add(int count)
    {
        T newObject = Instantiate(prefab);
        ReturnToPool(newObject);
    }

    public void ReturnToPool(T returnObject)
    {
        Debug.Log("return to pool: " + returnObject.name);
        returnObject.gameObject.SetActive(false);
        gameobjects.Enqueue(returnObject);
    }
}

