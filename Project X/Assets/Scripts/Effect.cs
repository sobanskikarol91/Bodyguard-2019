using UnityEngine;

public abstract class Effect : ScriptableObject 
{
    public abstract void CreateEffect(Transform transform);
}

public abstract class DeathEffect : Effect { }