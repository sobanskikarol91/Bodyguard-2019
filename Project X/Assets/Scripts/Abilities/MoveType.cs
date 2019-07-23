using UnityEngine;


public abstract class MoveType : ScriptableObject, IMovemenet
{
    protected Transform transform;
    protected MoveSettings settings;

    public virtual void Init(Transform transform, MoveSettings settings)
    {
        this.settings = settings;
        this.transform = transform;
    }

    public abstract void Move();
}