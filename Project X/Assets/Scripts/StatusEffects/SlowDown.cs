using System;
using UnityEngine;


[CreateAssetMenu(fileName = "SlowDown", menuName = "Effect/SlowDown")]
public class SlowDown : Status
{
    [Tooltip("Percentage of origin speed value")]
    [SerializeField, Range(0, 1)] float percentage = 0.8f;

    public override string Name => "Slow down";

    private MovingAbility movement;

    public override Coroutine CreateStatus()
    {
        movement.Speed *= percentage;
        return MonoBevahiourExtension.StartLerp(interactibleObject, 0, time, time, ReturnOrginSpeed, null);
    }

    protected override bool AreRequirementToAddStatusMet()
    {
        return movement = interactibleObject.GetComponent<MovingAbility>();
    }

    void ReturnOrginSpeed()
    {
        movement.Speed = movement.OriginSpeed;
        interactibleObject.Status.RemoveStatusFromList(Name);
    }
}