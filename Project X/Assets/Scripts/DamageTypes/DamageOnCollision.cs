using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : Damage
{
    private InteractiveObject hitObject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("c");
        hitObject = collision.gameObject.GetComponent<InteractiveObject>();

        if (hitObject == null) return;

        if (IsHitTargetOnDamageObjectsCollection(hitObject))
            HitCorrectObject();
    }

    private void HitCorrectObject()
    {
        Health health = hitObject.GetComponent<Health>();

        if (health)
            health.DoDamage(damage);
    }
}
