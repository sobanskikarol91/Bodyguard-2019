using UnityEngine;


public abstract class InputManager : ScriptableObject
{
    public abstract TwoAxisInput Movement { get; protected set; }
    public abstract TwoAxisInput Rotation { get; protected set; }
    public abstract void Init();
    public abstract void Execute();
}