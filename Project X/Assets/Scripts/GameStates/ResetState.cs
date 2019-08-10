using System;
using UnityEngine;

public class ResetState : IState
{
    private IRestart[] restartObjects;
    private Player player;
    private Action ExitActions;

    public ResetState(Action EnterActions = null)
    {
        restartObjects = GameManager.instance.GetComponents<IRestart>();
        player = GameManager.instance.Player;

        this.ExitActions = EnterActions;
    }

    public void Enter()
    {
        Array.ForEach(restartObjects, r => r.Restart());
        player.gameObject.SetActive(true);
        player.transform.position = Vector3.zero;
        ExitActions();
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }
}