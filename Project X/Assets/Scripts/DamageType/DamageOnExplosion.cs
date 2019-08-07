using UnityEngine;
using System.Linq;

public class DamageOnExplosion : Damagable 
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        InteractiveObject interactive = collision.gameObject.GetComponent<InteractiveObject>();

        if (!interactive) return;
        else if (!damageObjects.Contains(interactive.Type)) return;
        interactive.GetComponent<HealthAbility>()?.DoDamage(Damage);
    }
}