using System;
using UnityEngine;

public class Enemy : Character, IGameOver, IRestart
{
    private Animator animator;
    private Ability[] abilites;

    protected void Awake()
    {
        abilites = GetComponentsInChildren<Ability>();
        animator = GetComponent<Animator>();
        Type = ObjectType.Enemy;
    }

    public void OnGameOver()
    {
        Array.ForEach(abilites, a => a.enabled = false);
       // animator.SetTrigger("gameOver");
    }

    public void OnRestart()
    {
        animator.SetTrigger("Idle");
    }

    private void OnEnable()
    {
        Array.ForEach(abilites, a => a.enabled = true);
    }
}