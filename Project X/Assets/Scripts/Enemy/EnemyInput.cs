using UnityEngine;


public class EnemyInput : TwoAxisInput
{
    public override Vector2 Direction { get { return (player.transform.position).normalized; } }

    private Player player;


    public override void Execute()
    {
        OnInputUsing();
    }
}