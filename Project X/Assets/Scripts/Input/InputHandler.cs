using System;
using UnityEngine;

public abstract class InputHandler : MonoBehaviour
{
    public event Action InputUsed = delegate { };

    protected void OnInputUsed()
    {
        InputUsed();
    }
}


public interface IMovemenet
{
    void Move();
}

