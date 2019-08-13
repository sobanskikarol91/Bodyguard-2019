using UnityEngine;

[CreateAssetMenu(fileName = "RotateToMoveDirection", menuName = "Rotating/ToMoveDirection")]
public class RotateToMoveDirection : RotateType
{
    MovingAbility movingAbility;

    public override void Init(RotatingAbility ability)
    {
        base.Init(ability);
        movingAbility = ability.GetComponent<MovingAbility>();
    }

    public override void Execute()
    {
        SetNewRotation(movingAbility.MoveTypeInstance.Direction);
    }
}