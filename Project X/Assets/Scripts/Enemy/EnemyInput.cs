using UnityEngine;


public class EnemyInput : TwoAxisInput
{
    public override Vector2 Direction { get { return (player.transform.position - transform.position).normalized; } }

    private Player player;


    private void Start()
    {
        player = GameManager.instance.Player;
    }

    private void Update()
    {
        OnInputUsing();
    }
}