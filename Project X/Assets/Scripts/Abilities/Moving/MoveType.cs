using UnityEngine;

public abstract class MoveType : AbilityType<MovingAbility>
{
    protected Transform transform;
    protected MoveSettings settings;

    public override void Init(MovingAbility ability)
    {
        base.Init(ability);
        transform = ability.transform;
        settings = ability.Settings;
    }
}