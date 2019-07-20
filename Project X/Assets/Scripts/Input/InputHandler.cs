using System;
using UnityEngine;

public abstract class InputHandler : ScriptableObject
{
    public event Action InputStartUsing = delegate { };
    public event Action InputUsing = delegate { };
    public event Action InputEndUsing = delegate { };

    protected Touch touch;


    protected virtual void OnInputStartUsing()
    {
        InputStartUsing();
    }

    protected virtual void OnInputUsing()
    {
        InputUsing();
    }

    protected virtual void OnInputEndUsing()
    {
        InputEndUsing();
    }

    public abstract void Execute();
}


public interface IMovemenet
{
    void Move();
}