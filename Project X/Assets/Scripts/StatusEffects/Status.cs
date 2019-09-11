using UnityEngine;

public abstract class Status
{
    [SerializeField] protected float time;
    public abstract string Name { get; }
}
