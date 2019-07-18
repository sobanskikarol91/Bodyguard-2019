using UnityEngine;


public class EnemyInput : TwoAxisInput
{
    public override Vector2 Direction { get { return (player.transform.position).normalized; } }

    private Player player;


    private void Start()
    {
        player = GameManager.instance.Player;
    }

    public override void OnTouchStart(Touch touch)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTouching(Touch touch)
    {
        OnInputUsing();
    }

    public override void OnTouchEnd()
    {
        throw new System.NotImplementedException();
    }
}