using UnityEngine;

public abstract class MoveType : AbilityType<MovingAbility>
{
    protected Transform transform;
    public abstract Vector2 Direction { get;  }

    public override void Init(MovingAbility ability)
    {
        base.Init(ability);
        transform = ability.transform;
    }
}