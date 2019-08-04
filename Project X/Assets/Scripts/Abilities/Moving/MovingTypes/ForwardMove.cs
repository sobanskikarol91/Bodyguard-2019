using UnityEngine;

[CreateAssetMenu(fileName = "ForwardMove", menuName = "Moving/ForwardMove")]
public class ForwardMove : MoveType
{
    public override void Execute()
    {
        transform.position += transform.right * Time.deltaTime * settings.Speed;
    }
}