public abstract class ShootingType : AbilityType<ShootingAbility>
{
    private Weapon weapon;
    
    public override void Init(ShootingAbility ability)
    {
        base.Init(ability);
        weapon = ability.Weapon;
    }

    protected void TryShoot()
    {
            weapon.Attack();
    }

}