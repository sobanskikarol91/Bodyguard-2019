using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class ReturnToPool : MonoBehaviour
{
    public int Id;

    protected void ReturnObjectToPool()
    {
        ObjectPoolManager.instance.ReturnToPool(gameObject);
    }
}