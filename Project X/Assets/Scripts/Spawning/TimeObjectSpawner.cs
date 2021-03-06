﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class TimeObjectSpawner
{
    public float SpawTime { get { return spawnTime; } }
    [SerializeField] float spawnTime = 1f;

    public SpawnObjectSettings[] SpawnObjects { get { return spawnObjects; } }
    [SerializeField] SpawnObjectSettings[] spawnObjects;

    private Dictionary<float, GameObject> objectsPercantage = new Dictionary<float, GameObject>();

    public GameObject GetRandomObject()
    {
        if (objectsPercantage.Count == 0)
            CreateDictionary();

        float percantage = UnityEngine.Random.value;
        GameObject randomObject = GetObjectFromDictionary(percantage);
        return randomObject;
    }

    void CreateDictionary()
    {
        float totalPercantage = 0;
        Array.ForEach(SpawnObjects, e => totalPercantage += e.Percentage);

        float previousObjectPercantage = 0;

        for (int i = 0; i < SpawnObjects.Length; i++)
        {
            SpawnObjectSettings newObject = SpawnObjects[i];
            float percantage = newObject.Percentage / totalPercantage;
            previousObjectPercantage += percantage;
            objectsPercantage.Add(previousObjectPercantage, newObject.Prefab);
        }
    }

    GameObject GetObjectFromDictionary(float percantage)
    {
        if (objectsPercantage.Count == 1) return objectsPercantage.First().Value;

        GameObject result = null;

        for (int i = 0; i < objectsPercantage.Count; i++)
        {
            if (percantage <= objectsPercantage.ElementAt(i).Key)
                return objectsPercantage.ElementAt(i).Value;
        }

        Debug.LogError("Can't find object to spawn!");
        return result;
    }
}

[Serializable]
public class SpawnObjectSettings
{
    public float Percentage { get { return percentage; } }
    [Range(0, 1), SerializeField] float percentage = 1f;

    public GameObject Prefab { get { return prefab; } }
    [SerializeField] GameObject prefab;
}