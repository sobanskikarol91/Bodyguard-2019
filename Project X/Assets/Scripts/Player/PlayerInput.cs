using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerInput : MonoBehaviour, IInput
{
    public Vector2 Movement { get { return new Vector2(Input.GetAxis(horizAxis), Input.GetAxis(vertAxis)); } }

    private const string vertAxis = "Vertical";
    private const string horizAxis = "Horizontal";
}