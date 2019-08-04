using UnityEngine;

public abstract class TwoAxisInput : InputHandler
{
    public virtual Vector2 Direction { get; protected set; }
}