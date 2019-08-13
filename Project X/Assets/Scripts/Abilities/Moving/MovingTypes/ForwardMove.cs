using UnityEngine;

[CreateAssetMenu(fileName = "ForwardMove", menuName = "Moving/ForwardMove")]
public class ForwardMove : MoveType
{
    public override Vector2 Direction { get => transform.right; }

    public override void Execute()
    {
        transform.position += transform.right * Time.deltaTime * ability.Speed;
    }
}