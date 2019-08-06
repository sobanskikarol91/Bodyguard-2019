using System;
using UnityEngine;


public class HealthAbility : MonoBehaviour, IDeath
{
    public event Action Death;

    [SerializeField] float health;
    [SerializeField] DeathEffect[] deathEffects;
    [SerializeField] GameObject damageEffect;
    [SerializeField] bool godMode;

    private float currentHealth;
    private bool isAlive = true;
    private Animator animator;

    private void Awake()
    {
        currentHealth = health;
        animator = GetComponent<Animator>();
    }

    public void DoDamage(float damage)
    {
        if (godMode || !isAlive) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
            OnDeath();
        else
            OnDamage();
    }

    private void OnDamage()
    {
        animator.SetTrigger("isDamage");
    }

    private void OnDeath()
    {
        CreateDeathEffects();
        isAlive = false;
        Death();
    }

    private void CreateDeathEffects()
    {
        Array.ForEach(deathEffects, d => d.CreateEffect(transform));
    }

    private void OnEnable()
    {
        isAlive = true;
        currentHealth = health;
    }
}
