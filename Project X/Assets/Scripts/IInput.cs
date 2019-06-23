using UnityEngine;

public interface IDirectionInput
{
    Vector2 Direction { get; }
}

public interface IMoveInput : IDirectionInput
{

}

public interface IRotateInput : IDirectionInput
{

}

public interface IMovemenet
{
    void Move();
}

