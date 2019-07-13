using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDeath
{
    [SerializeField] float health;
    [SerializeField] GameObject deathEffect;
    [SerializeField] bool godMode;

    private float currentHealth;

    public event Action Death;

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
        if (godMode) return;

        health -= damage;

        if (health <= 0)
            OnDeath();
    }

    private void OnDeath()
    {
        Death();
    }
}
