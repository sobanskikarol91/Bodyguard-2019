using UnityEngine;
using System.Linq;

public class DamageOnExplosion : Damagable
{
    private new Collider2D collider;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InteractiveObject interactive = collision.gameObject.GetComponent<InteractiveObject>();

        if (!interactive) return;
        else if (!damageObjects.Contains(interactive.Type)) return;
        interactive.GetComponent<HealthAbility>()?.DoDamage(Damage);

        collider.enabled = false;
    }

    private void OnEnable()
    {
        collider.enabled = true;
    }
}