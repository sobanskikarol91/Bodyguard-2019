using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerKeyboard : MonoBehaviour, IMovementInput
{
    public Vector2 Movement { get { return new Vector2(Input.GetAxis(horizAxis), Input.GetAxis(vertAxis)).normalized; } }
    private const string vertAxis = "Vertical";
    private const string horizAxis = "Horizontal";
}