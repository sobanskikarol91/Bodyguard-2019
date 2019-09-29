using System;
using UnityEngine;


[CreateAssetMenu(fileName = "SlowDown", menuName = "Effect/SlowDown")]
public class SlowDown : Status
{
    [Tooltip("Percentage of origin speed value")]
    [SerializeField, Range(0, 1)] float percentage = 0.8f;
    [SerializeField] Color32 color;
    public override string Name => "Slow down";

    private MovingAbility movement;

    public override Coroutine CreateStatus()
    {
        SpriteRenderer[] sprites = movement.GetComponentsInChildren<SpriteRenderer>();
        Array.ForEach(sprites, s => s.color = color);

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