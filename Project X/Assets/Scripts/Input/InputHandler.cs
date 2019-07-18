using System;
using UnityEngine;

public abstract class InputHandler : ScriptableObject
{
    public event Action InputStartUsing = delegate { };
    public event Action InputUsing = delegate { };
    public event Action InputEndUsing = delegate { };

    protected Touch touch;


    protected void OnInputStartUsing()
    {
        InputStartUsing();
    }

    protected void OnInputUsing()
    {
        InputUsing();
    }

    protected void OnInputEndUsing()
    {
        InputEndUsing();
    }

    public abstract void OnTouchStart(Touch touch);
    public abstract void OnTouching(Touch touch);
    public abstract void OnTouchEnd();
}


public interface IMovemenet
{
    void Move();
}