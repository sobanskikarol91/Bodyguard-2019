using System;
using UnityEngine;

public class ResetState : IState
{
    private IRestart[] restartObjects;
    private Player player;

    public ResetState()
    {
        restartObjects = GameManager.instance.GetComponents<IRestart>();
        player = GameManager.instance.Player;
    }

    public void Enter()
    {
        Array.ForEach(restartObjects, r => r.Restart());
        player.gameObject.SetActive(true);
        player.transform.position = Vector3.zero;
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }
}