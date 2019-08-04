using UnityEngine;


[CreateAssetMenu(fileName = "PlayerMove", menuName = "Moving/PlayerSimple")]
public class PlayerMove : MoveType
{
    PlayerInput input;

    public override void Init(MovingAbility ability)
    {
        base.Init(ability);
        input = GameManager.instance.Platform.GetPlayerInputDependsOnPlatform();
    }

    public override void Execute()
    {
        transform.position += (Vector3)(ability.Speed * input.Moving.Direction * Time.deltaTime);
    }
}