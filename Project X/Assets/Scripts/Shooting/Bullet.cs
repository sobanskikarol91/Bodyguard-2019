﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Bullet : MonoBehaviour, IMovement
{
    [SerializeField] protected float speed = 10;


    private void Update()
    {
        Move();
    }

    public virtual void Move()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }
}