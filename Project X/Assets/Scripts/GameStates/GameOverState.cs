using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameOverState : State 
{
    Action ExitActions;

    public GameOverState(Action ExitActions)
    {
        this.ExitActions = ExitActions;
    }

    public override void Start()
    {
        SlowMotion.instance.RunEffect(0.2f, 1, Exit);
    }

    public override void Execute()
    {
        
    }

    public override void Exit()
    {
        ExitActions();
    }
}