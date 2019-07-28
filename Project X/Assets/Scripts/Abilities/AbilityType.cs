using UnityEngine;

public class AbilityType<Ability> : ScriptableObject
{
    protected Ability ability;

    public virtual void Init(Ability ability)
    {
        this.ability = ability;
    }
}

public abstract class RotateType : AbilityType<RotatingAbility>
{
    [SerializeField] protected float speed = 10;

    protected void SetNewRotation(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        SetNewRotation(angle);
    }

    protected void SetNewRotation(float angle)
    {
        ability.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public abstract void Rotate();
}

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