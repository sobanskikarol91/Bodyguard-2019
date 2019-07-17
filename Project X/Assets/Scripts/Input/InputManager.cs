using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class InputManager : ScriptableObject
{
    public abstract TwoAxisInput Movement { get; protected set; }
    public abstract TwoAxisInput Rotation { get; protected set; }
}

public class PCInput : InputManager
{
    public override TwoAxisInput Movement { get; protected set; }
    public override TwoAxisInput Rotation { get; protected set; }
}

[CreateAssetMenu(fileName = "MobileInput", menuName = "Input/Mobile")]
public class MobileInput : InputManager
{
    [SerializeField] TwoAxisInput moveJoystick;
    [SerializeField] TwoAxisInput rotateJoystick;

    public override TwoAxisInput Movement { get; protected set; }
    public override TwoAxisInput Rotation { get; protected set; }


    private void Awake()
    {
        Movement = Instantiate(moveJoystick).GetComponent<TwoAxisInput>();
        Rotation = Instantiate(rotateJoystick.gameObject).GetComponent<TwoAxisInput>();
    }
}