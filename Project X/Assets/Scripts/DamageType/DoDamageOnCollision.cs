using System;
using UnityEngine;

public class DoDamageOnCollision : Damagable
{
    [SerializeField] CollisionEffect[] collisionEffects;

    private InteractiveObject hitObject;
    private Collision2D bodyCollider;

    private void Awake()
    {
        bodyCollider = GetComponent<Collision2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitObject = collision.gameObject.GetComponent<InteractiveObject>();

        if (hitObject == null) return;

        if (IsHitTargetOnDamageObjectsCollection(hitObject))
            HitResult(collision);
    }

    bool IsHitMainCollider(Collision2D collision)
    {
        foreach(ContactPoint2D c in collision.contacts)
        {
            Debug.Log(c.collider.name);
        }
        return false;
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
