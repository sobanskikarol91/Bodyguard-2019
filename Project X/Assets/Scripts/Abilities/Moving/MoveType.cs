using UnityEngine;


public abstract class MoveType : ScriptableObject
{
    protected Transform transform;
    [SerializeField] protected MoveSettings settings;

    public virtual void Init(Transform transform)
    {
        this.transform = transform;
    }

    public abstract void Move();
}