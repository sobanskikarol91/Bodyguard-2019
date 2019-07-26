﻿using UnityEngine;

[CreateAssetMenu(fileName = "PlayerRotation", menuName = "Rotating/Player")]
public class PlayerRotating : RotateType
{
    private PlayerInput input;

    public override void Init(RotatingAbility ability)
    {
        base.Init(ability);
        input = GameManager.instance.Platform.GetPlayerInputDependsOnPlatform();
        input.Init();
        input.Rotating.Using += Rotate;
    }

    private void OnEnable()
    {
        if (input) input.Rotating.Using += Rotate;
    }

    private void OnDisable()
    {
        if (input) input.Rotating.Using -= Rotate;
    }

    void Rotate()
    {
        ability.Rotate(input.Rotating.Direction);
    }
}