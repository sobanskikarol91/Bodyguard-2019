using UnityEngine;


public abstract class InputManager : ScriptableObject
{
    public abstract TwoAxisInput Moving { get; protected set; }
    public abstract TwoAxisInput Rotating { get; protected set; }
    public abstract InputHandler Shooting { get; protected set; }

    public abstract void Init();
    public abstract void Execute();
}