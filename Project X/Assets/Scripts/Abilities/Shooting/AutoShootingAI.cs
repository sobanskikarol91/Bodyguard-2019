using UnityEngine;

[CreateAssetMenu(fileName = "AutoShooting", menuName = "Shooting/AutoShooting")]
public class AutoShootingAI : ShootingType
{
    private Player player;

    public override void Init(ShootingAbility ability)
    {
        base.Init(ability);
        ability.ReadyToShoot += ability.ShotEffect;
    }

    private void OnEnable()
    {
        if (ability) ability.ReadyToShoot += ability.ShotEffect;
    }

    private void OnDisable()
    {
        if (ability) ability.ReadyToShoot -= ability.ShotEffect;
    }
}