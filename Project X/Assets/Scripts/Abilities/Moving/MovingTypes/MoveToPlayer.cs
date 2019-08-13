using UnityEngine;

[CreateAssetMenu(fileName = "MoveToPlayer", menuName = "Moving/MoveToPlayer")]
public class MoveToPlayer : MoveType
{
    private Player player;

    public override Vector2 Direction => (player.transform.position - transform.position).normalized;

    public override void Init(MovingAbility ability)
    {
        base.Init(ability);
        player = GameManager.instance.Player;
    }

    public override void Execute()
    {
        transform.position += (Vector3)(ability.Speed * Direction * Time.deltaTime);
    }
}