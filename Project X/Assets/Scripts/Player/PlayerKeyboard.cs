using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlayerKeyboard : MonoBehaviour, IDirectionInput
{
    public Vector2 Direction { get { return new Vector2(Input.GetAxis(horizAxis), Input.GetAxis(vertAxis)).normalized; } }
    private const string vertAxis = "Vertical";
    private const string horizAxis = "Horizontal";
    public event Action OnUse;
}