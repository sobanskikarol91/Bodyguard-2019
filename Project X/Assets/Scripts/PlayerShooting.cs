using System;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerShooting", menuName = "Shooting/Player")]
public class PlayerShooting : ShootingType
{
    private PlayerInput input;

    public override void Init(Action TryShoot)
    {
        base.Init(TryShoot);
        input = GameManager.instance.Platform.GetPlayerInputDependsOnPlatform();
        input.Shooting.EndUsing += TryShoot;
    }

    private void OnEnable()
    {
        if (input) input.Shooting.EndUsing += TryShoot;
    }

    private void OnDisable()
    {
        input.Shooting.EndUsing -= TryShoot;
    }
}