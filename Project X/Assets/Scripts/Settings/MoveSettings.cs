using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Settings/Movement", fileName = "Settings")]
public class MoveSettings : ScriptableObject
{
    public Vector2 Speed { get { return new Vector2(horizontalSpeed, verticalSpeed); } }

    [SerializeField] float horizontalSpeed = 10;
    [SerializeField] float verticalSpeed = 10f;
}