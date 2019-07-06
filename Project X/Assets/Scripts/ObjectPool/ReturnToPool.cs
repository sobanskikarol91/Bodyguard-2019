using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class ReturnToPool : MonoBehaviour
{
    protected IPoolObject objectToReturn;

    protected virtual void Awake()
    {
        objectToReturn = GetComponent<IPoolObject>();
    }
}