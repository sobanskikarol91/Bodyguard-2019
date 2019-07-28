using UnityEngine;

[CreateAssetMenu(fileName = "RotateToPlayer", menuName = "Rotating/RotateToPlayer")]
public class RotateToPlayer : RotateType
{
    private Transform player;

    public override void Init(RotatingAbility ability)
    {
        base.Init(ability);
        player = GameManager.instance.Player.transform;
    }

    public override void Rotate()
    {
        Vector2 directionToPlayer = player.position - ability.transform.position;
        SetNewRotation(directionToPlayer);
    }
}