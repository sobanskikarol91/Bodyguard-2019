using System;
using UnityEngine;

public class DoDamageOnCollision : Damagable
{
    [SerializeField] CollisionEffect[] collisionEffects;
    private InteractiveObject hitObject;
    private Collider2D bodyCollider;
    

    private void Awake()
    {
        bodyCollider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitObject = GetInteractiveObject(collision);

        if (hitObject && IsHitTargetOnDamageObjectsCollection(hitObject))
            HitResult(collision);
    }

    InteractiveObject GetInteractiveObject(Collision2D collision)
    {
        return collision.contacts[0].collider.GetComponent<InteractiveObject>();
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
