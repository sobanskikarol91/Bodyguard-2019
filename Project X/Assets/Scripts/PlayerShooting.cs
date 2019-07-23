using UnityEngine;

[CreateAssetMenu(fileName = "PlayerShooting", menuName = "Shooting/Player")]
public class PlayerShooting : ShootingType
{
    private PlayerInput input;

    public override void Init(ShootingAbility ability)
    {
        base.Init(ability);
        input = GameManager.instance.Platform.GetPlayerInputDependsOnPlatform();
        input.Shooting.EndUsing += ability.TryShoot;
    }

    private void OnEnable()
    {
        if (input && ability) input.Shooting.EndUsing += ability.TryShoot;
    }

    private void OnDisable()
    {
        if (input && ability) input.Shooting.EndUsing -= ability.TryShoot;
    }
}