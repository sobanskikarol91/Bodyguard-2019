using UnityEngine;

public class DestroySelfOnCollision : MonoBehaviour
{
    private DoDamageOnCollision damageOnCollision;
    private HealthAbility health;

    protected void Awake()
    {
        health = GetComponent<HealthAbility>();
        damageOnCollision = GetComponent<DoDamageOnCollision>();
    }

    private void OnEnable()
    {
        if (damageOnCollision != null)
            damageOnCollision.DoDamage += health.KillImmediately;
    }

    private void OnDisable()
    {
        if (damageOnCollision != null)
            damageOnCollision.DoDamage -= health.KillImmediately;
    }
}