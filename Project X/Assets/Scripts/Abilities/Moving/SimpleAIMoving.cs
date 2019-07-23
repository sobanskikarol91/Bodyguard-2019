using UnityEngine;


[CreateAssetMenu(fileName = "AIMoving", menuName = "MoveType/FollowPlayer")]
public class SimpleAIMoving : MoveType
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