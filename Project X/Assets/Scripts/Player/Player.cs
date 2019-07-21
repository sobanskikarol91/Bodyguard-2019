using System;
using UnityEngine;

public class Player : Character
{
    protected override void Awake()
    {
        Debug.Log("Awake" + gameObject.name);
        base.Awake(); 
        Type = ObjectType.Player;
        input = PlatformManager.GetPlayerInputDependsOnPlatform();
        GetComponent<MovingAbility>().Input = input.Moving;
        GetComponent<ShootingAbility>().Input = input.Shooting;
        GetComponent<RotationAbility>().Input = input.Rotating;
    }
}