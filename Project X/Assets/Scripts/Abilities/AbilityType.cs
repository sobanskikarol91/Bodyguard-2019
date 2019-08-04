using UnityEngine;

public abstract class AbilityType<Ability> : ScriptableObject
{
    protected Ability ability;

    public virtual void Init(Ability ability)
    {
        this.ability = ability;
    }

    public abstract void Execute();
}