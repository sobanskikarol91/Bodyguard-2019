using UnityEngine;

public class Enemy : Character, IGameOver, IRestart
{
    private Animator animator;

    protected void Awake()
    {
        animator = GetComponent<Animator>();
        Type = ObjectType.Enemy;
    }

    public void OnGameOver()
    {
        animator.SetTrigger("gameOver");
    }

    public void OnRestart()
    {
        animator.SetTrigger("Idle");
    }
}