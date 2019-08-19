public abstract class ShootingType : AbilityType<ShootingAbility>
{
    protected void TryShoot()
    {
        ability.CurrentWeapon.TryAttack();
    }
}