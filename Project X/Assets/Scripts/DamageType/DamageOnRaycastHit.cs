using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DamageOnRaycastHit : Damagable
{
    public void CastRay(Vector3 origin, Vector3 direction, float length, ObjectType damagable)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(origin, direction, length);

        if (hits.Length > 0)
        {
            Array.ForEach(hits, h => CheckHitObject(h, damagable));
        }
    }

    private void CheckHitObject(RaycastHit2D hit, ObjectType damagable)
    {
        Debug.Log("hit: " + hit.collider.name);
        InteractiveObject interactive = hit.collider.gameObject.GetComponent<InteractiveObject>();

        if (!interactive) return;
        else if (interactive.Type != damagable) return;
        interactive.GetComponent<Health>()?.DoDamage(damage);
    }
}