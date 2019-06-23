using System;
using UnityEngine;

public interface IInput
{
    event Action OnUse;
}

public interface IDirectionInput : IInput
{
    Vector2 Direction { get; }
}

public interface IMoveInput : IDirectionInput
{

}

public interface IRotateInput : IDirectionInput
{

}

public interface IShootingInput : IInput
{

}

public interface IShooting : IDirectionInput
{

}

public interface IMovemenet
{
    void Move();
}

