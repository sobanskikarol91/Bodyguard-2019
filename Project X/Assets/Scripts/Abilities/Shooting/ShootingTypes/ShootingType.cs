public abstract class ShootingType : AbilityType<ShootingAbility>
{
    public override void Init(ShootingAbility ability)
    {
        base.Init(ability);
    }

    protected void TryShoot()
    {
        ability.Weapon.Attack();
    }
}