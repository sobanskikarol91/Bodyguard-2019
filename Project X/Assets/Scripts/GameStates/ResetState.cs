using System;
using UnityEngine;

public class ResetState : IState
{
    private SpawnManager spawnManager;
    private IRestart[] restartObjects;
    private Player player;
    private Action EnterActions;
    private LightManager lightManager;

    public ResetState(Action EnterActions = null)
    {
        spawnManager = GameManager.instance.GetComponent<SpawnManager>();
        restartObjects = GameManager.instance.GetComponents<IRestart>();
        lightManager = GameManager.instance.GetComponent<LightManager>();
        player = GameManager.instance.Player;

        this.EnterActions = EnterActions;
    }

    public void Enter()
    {
        Array.ForEach(restartObjects, r => r.OnRestart());
        player.gameObject.SetActive(true);
        player.transform.position = Vector3.zero;
        lightManager.ReturnSpotAngleToOrigin(0.5f);
        CameraZoom.instance.ZoomOut(0.5f, 2f);
        EnterActions();
        PlayEnemiesAnimation();
    }

    private void PlayEnemiesAnimation()
    {
        spawnManager.spawnedEnemies.ForEach(s => s.GetComponent<IRestart>().OnRestart());
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }
}