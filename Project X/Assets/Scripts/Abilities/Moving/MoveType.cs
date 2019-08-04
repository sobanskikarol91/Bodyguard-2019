using UnityEngine;

public abstract class MoveType : AbilityType<MovingAbility>
{
    protected Transform transform;

    public override void Init(MovingAbility ability)
    {
        base.Init(ability);
        transform = ability.transform;
    }
}