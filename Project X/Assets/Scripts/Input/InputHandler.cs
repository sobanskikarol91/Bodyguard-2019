using System;
using UnityEngine;

public abstract class InputHandler : ScriptableObject
{
    public event Action StartUsing = delegate { };
    public event Action Using = delegate { };
    public event Action EndUsing = delegate { };


    protected virtual void OnInputStartUsing()
    {
        StartUsing();
    }

    protected virtual void OnInputUsing()
    {
        Using();
    }

    protected virtual void OnInputEndUsing()
    {
        EndUsing();
    }

    public abstract void Execute();
}