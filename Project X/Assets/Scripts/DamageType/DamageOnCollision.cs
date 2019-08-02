using UnityEngine;

public class DamageOnCollision : Damagable
{
    private InteractiveObject hitObject;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitObject = collision.gameObject.GetComponent<InteractiveObject>();

        if (hitObject == null) return;

        if (IsHitTargetOnDamageObjectsCollection(hitObject))
            HitResult();
    }

    private void HitResult()
    {
        HealthAbility health = hitObject.GetComponent<HealthAbility>();

        if (health)
            health.DoDamage(Damage);

        OnDamage();
    }
}
