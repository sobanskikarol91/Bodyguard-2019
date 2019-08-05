using UnityEngine;

[CreateAssetMenu(fileName = "MoveToPlayer", menuName = "Moving/MoveToPlayer")]
public class MoveToPlayer : MoveType
{
    private Player player;

    public override void Init(MovingAbility ability)
    {
        base.Init(ability);
        player = GameManager.instance.Player;
    }

    public override void Execute()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        transform.position += (Vector3)(ability.Speed * direction * Time.deltaTime);
    }
}