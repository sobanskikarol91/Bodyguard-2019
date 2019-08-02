using System;
using UnityEngine;


public class HealthAbility : MonoBehaviour, IDeath
{
    public event Action Death;

    [SerializeField] float health;
    [SerializeField] GameObject deathEffect;
    [SerializeField] bool godMode;

    private float currentHealth;
    private bool isAlive = true;


    private void Awake()
    {
        currentHealth = health;
        if (deathEffect) Death += ShowDeathEffect;
    }

    private void ShowDeathEffect()
    {
        Transform effect = ObjectPoolManager.instance.Get(deathEffect).transform;
        effect.position = transform.position;
    }

    public void DoDamage(float damage)
    {
        if (godMode || !isAlive) return;

        health -= damage;

        if (health <= 0)
            OnDeath();
    }

    private void OnDeath()
    {
        isAlive = false;
        Death();
    }

    private void OnEnable()
    {
        isAlive = true;
    }
}
