using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] GameObject deathEffect;
    [SerializeField] bool godMode;

    private float currentHealth;
    

    private void Awake()
    {
        currentHealth = health;
    }

    public void DoDamage(float damage)
    {
        if (godMode) return;

        health -= damage;

        if (health <= 0)
            Death();
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
