using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "PlayerMove", menuName = "MoveType/PlayerSimple")]
public class PlayerMove : MoveType
{
    PlayerInput input;

    public override void Init(Transform transform, MoveSettings settings)
    {
        input = GameManager.instance.Platform.GetPlayerInputDependsOnPlatform();
        base.Init(transform, settings);
    }

    public override void Move()
    {
        transform.position += (Vector3)(settings.Speed * input.Moving.Direction * Time.deltaTime);
    }
}