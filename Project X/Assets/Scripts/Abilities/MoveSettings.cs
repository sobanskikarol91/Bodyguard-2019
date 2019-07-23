using System;
using UnityEngine;

[Serializable]
public class MoveSettings
{
    public Vector2 Speed { get { return new Vector2(horizontalSpeed, verticalSpeed); } }

    [SerializeField] float horizontalSpeed = 10;
    [SerializeField] float verticalSpeed = 10f;
}