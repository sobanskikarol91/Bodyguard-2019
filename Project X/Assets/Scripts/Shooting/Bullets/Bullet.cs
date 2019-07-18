﻿using UnityEngine;


public class Bullet : InteractiveObject, IMovemenet
{
    [SerializeField] protected float speed = 10;


    private void Awake()
    {
        Type = ObjectType.Bullet;        
    }

    private void Update()
    {
        Move();
    }

    public virtual void Move()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }
}