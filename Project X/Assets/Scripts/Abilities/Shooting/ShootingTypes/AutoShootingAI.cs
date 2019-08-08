using UnityEngine;

[CreateAssetMenu(fileName = "AutoShooting", menuName = "Shooting/AutoShooting")]
public class AutoShootingAI : ShootingType
{
    [SerializeField] float desireDistanceToPlayer = 8f;

    private Transform player;

    public override void Init(ShootingAbility ability)
    {
        base.Init(ability);
        player = GameManager.instance.Player.transform;
    }
    public override void Execute()
    {
        DecreaseTimeToShoot();

        if (IsReachedDesireDistance())
            TryShoot();
    }

    bool IsReachedDesireDistance()
    {
        return Vector3.Distance(player.position, ability.transform.position) < desireDistanceToPlayer;
    }
}