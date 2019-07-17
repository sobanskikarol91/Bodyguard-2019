using System;
using UnityEngine;


public abstract class Weapon : ScriptableObject
{
    public GameObject Bullet { get { return bullet; } }
    public float RefireRate { get { return refireRate; } }

    [SerializeField] GameObject bullet;
    [SerializeField] float refireRate = 0.1f;

    public abstract void Shoot(Transform shotPosition);
}
