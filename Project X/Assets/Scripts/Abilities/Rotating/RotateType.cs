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
        Quaternion rotation = Quaternion.AngleAxis(angle, ability.transform.forward);
        ability.transform.rotation = Quaternion.Slerp(ability.transform.rotation, rotation, ability.Speed * Time.deltaTime);
    }
}