using System;
using System.Collections;
using System.Collections.Generic;
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
        Health health = hitObject.GetComponent<Health>();

        if (health)
            health.DoDamage(damage);

        OnDamage();
    }
}
