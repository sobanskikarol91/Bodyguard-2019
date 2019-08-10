using System;
using UnityEngine;

public class ResetState : IState
{
    private IRestart[] restartObjects;
    private Player player;
    private Action EnterActions;
    private LightManager lightManager;

    public ResetState(Action EnterActions = null)
    {
        restartObjects = GameManager.instance.GetComponents<IRestart>();
        lightManager = GameManager.instance.GetComponent<LightManager>();
        player = GameManager.instance.Player;

        this.EnterActions = EnterActions;
    }

    public void Enter()
    {
        Array.ForEach(restartObjects, r => r.Restart());
        player.gameObject.SetActive(true);
        player.transform.position = Vector3.zero;
        lightManager.ReturnSpotAngleToOrigin(0.5f);
        CameraZoom.instance.ZoomOut(0.5f, 2f);
        EnterActions();
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }
}