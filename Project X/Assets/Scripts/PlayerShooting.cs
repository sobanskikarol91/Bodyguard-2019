using UnityEngine;

[CreateAssetMenu(fileName = "PlayerShooting", menuName = "Shooting/Player")]
public class PlayerShooting : ShootingType
{
    private PlayerInput input;

    public override void Init(ShootingAbility ability)
    {
        base.Init(ability);
        input = GameManager.instance.Platform.GetPlayerInputDependsOnPlatform();
        input.Shooting.EndUsing += TryShoot;
    }

    public override void Execute()
    {
        DecreaseTimeToShoot();
    }
}