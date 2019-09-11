using System;
using UnityEngine;


public class SlowDown : Status
{
    [Tooltip("Percentage of origin speed value")]
    [SerializeField, Range(0, 1)] float percentage = 0.8f;

    public override string Name => "Slow down";

    private MovingAbility movement;

    public override Coroutine CreateStatus()
    {
        float originSpeed = movement.Speed;
        movement.Speed *= percentage;
        Action ReturnOrginSpeed = () => movement.Speed = originSpeed;
        return MonoBevahiourExtension.StartLerp(movement, 0, time, 0, ReturnOrginSpeed, null);
    }

    protected override bool AreRequirementToAddStatusMet()
    {
        return movement = character.GetComponent<MovingAbility>();
    }
}