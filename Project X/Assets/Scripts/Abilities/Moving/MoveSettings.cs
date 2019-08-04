using System;
using UnityEngine;

[Serializable]
public class MoveSettings
{
    public float Speed { get { return speed; } }

    [SerializeField] float speed = 10;
}