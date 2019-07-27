using UnityEngine;


[CreateAssetMenu(fileName = "AIMoving", menuName = "Moving/FollowPlayer")]
public class FollowPlayer : MoveType
{
    private Player player;

    public override void Init(Transform transform)
    {
        base.Init(transform);
        player = GameManager.instance.Player;
    }

    public override void Move()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        transform.position += (Vector3)(settings.Speed * direction * Time.deltaTime);
    }
}