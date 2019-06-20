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

        return gameobjects.Dequeue();
    }

    private void Add(int count)
    {
        T newObject = Instantiate(prefab);
        SetToPool(newObject);
    }

    public void SetToPool(T gameobject)
    {
        gameObject.SetActive(false);
        gameobjects.Enqueue(gameobject);
    }
}

