using System;
using UnityEngine;


public class HealthAbility : MonoBehaviour, IDeath
{
    public event Action Death;

    [SerializeField] float health;
    [SerializeField] GameObject deathEffects;
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

    public void DoDamage(float damage = 1)
    {
        if (godMode || !isAlive) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
            OnDeath();
        else
            OnDamage();
    }

    public void KillImmediately()
    {
        currentHealth = 0;
        DoDamage();
    }

    private void OnDamage()
    {
        if (damageEffect) CreateEffect(damageEffect);
        animator.SetTrigger("isDamage");
    }

    private void OnDeath()
    {
        if (deathEffects) CreateEffect(deathEffects);
        isAlive = false;
        Death();
    }

    private void CreateEffect(GameObject prefab)
    {
        Transform instance = ObjectPoolManager.instance.Get(prefab).transform;
        instance.position = transform.position;
    }

    private void OnEnable()
    {
        isAlive = true;
        currentHealth = health;
    }
}