using UnityEngine;

public abstract class ShootingEffect : ScriptableObject
{
    protected ShootingAbility ability;

    public void Init(ShootingAbility ability)
    {
        this.ability = ability;
    }

    public abstract void OnShoot(Transform bullet);
}