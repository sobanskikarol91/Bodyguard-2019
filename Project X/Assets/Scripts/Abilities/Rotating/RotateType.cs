using UnityEngine;

public abstract class RotateType : AbilityType<RotatingAbility>
{
    protected void SetNewRotation(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        SetNewRotation(angle);
    }

    protected void SetNewRotation(float angle)
    {
        ability.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}