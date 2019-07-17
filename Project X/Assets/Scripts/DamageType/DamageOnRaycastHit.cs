using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DamageOnRaycastHit : Damagable
{
    public void CastRay(Vector3 origin, Vector3 direction, float length, ObjectType damagable)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, length);

        if (hit)
        {
            InteractiveObject interactive = hit.collider.gameObject.GetComponent<InteractiveObject>();

            if (!interactive) return;
            else if (interactive.Type != damagable) return;

            Health health = interactive.GetComponent<Health>();

            if (health) return;

            health.DoDamage(damage);
        }
    }
}