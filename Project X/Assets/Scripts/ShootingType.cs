using UnityEngine;

public abstract class ShootingType : ScriptableObject 
{
    protected ShootingAbility ability;

    public virtual void Init(ShootingAbility ability)
    {
        this.ability = ability;       
    }
}