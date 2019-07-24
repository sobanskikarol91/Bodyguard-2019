using UnityEngine;

public abstract class RotateType : ScriptableObject 
{
    protected RotatingAbility ability;

    public virtual void Init(RotatingAbility ability)
    {
        this.ability = ability;
    }
}