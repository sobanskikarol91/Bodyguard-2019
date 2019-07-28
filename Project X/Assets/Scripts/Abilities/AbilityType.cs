using UnityEngine;

public class AbilityType<Ability> : ScriptableObject 
{
    protected Ability ability;

    public virtual void Init(Ability ability)
    {
        this.ability = ability;
    }
}

public abstract class RotateType : AbilityType<RotatingAbility> { }
public abstract class ShootingType : AbilityType<ShootingAbility> { }
public abstract class MoveType : AbilityType<MovingAbility>
{
    protected Transform transform;
    [SerializeField] protected MoveSettings settings;

    public override void Init(MovingAbility ability)
    {
        base.Init(ability);
        transform = ability.transform;
    }

    public abstract void Move();
}