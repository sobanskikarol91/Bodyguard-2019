using System;
using UnityEngine;

public class DoDamageOnCollision : Damagable
{
    [SerializeField] CollisionEffect[] collisionEffects;

    private InteractiveObject hitObject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitObject = collision.gameObject.GetComponent<InteractiveObject>();

        if (hitObject == null) return;

        if (IsHitTargetOnDamageObjectsCollection(hitObject))
            HitResult(collision);
    }

    private void HitResult(Collision2D collision)
    {
        HealthAbility health = hitObject.GetComponent<HealthAbility>();

        health?.DoDamage(Damage);
        ShowEffects(collision);
        OnDamage();
    }

    private void ShowEffects(Collision2D collision)
    {
        Array.ForEach(collisionEffects, e => e.OnCollision(collision, transform));
    }
}
