using System;
using UnityEngine;


public class HealthAbility : MonoBehaviour, IDeath
{
    public event Action Death;

    [SerializeField]  float health;
    [SerializeField] GameObject deathEffect;
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
        CreateEffect(damageEffect);
        animator.SetTrigger("isDamage");
    }

    private void OnDeath()
    {
        CreateEffect(deathEffect);
        isAlive = false;
        Death();
    }

    private void OnEnable()
    {
        isAlive = true;
        currentHealth = health;
    }

    void CreateEffect(GameObject prefab)
    {
        Transform effect = ObjectPoolManager.instance.Get(prefab).transform;
        effect.position = transform.position;
    }
}
