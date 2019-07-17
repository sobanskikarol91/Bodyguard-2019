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