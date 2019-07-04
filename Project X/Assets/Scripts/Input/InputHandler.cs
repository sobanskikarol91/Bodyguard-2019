using System;
using UnityEngine;

public abstract class InputHandler : MonoBehaviour
{
    public event Action InputStartUsing = delegate { };
    public event Action InputUsing = delegate { };
    public event Action InputEndUsing = delegate { };


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
}


public interface IMovemenet
{
    void Move();
}