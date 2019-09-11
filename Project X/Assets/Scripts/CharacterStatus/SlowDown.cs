using System;
using UnityEngine;


public class SlowDown : Status
{
    [Tooltip("Percentage of origin speed value")]
    [SerializeField, Range(0, 1)] float percentage = 0.8f;

    private Character character;
    private MovingAbility movement;


    private void TryToSlowDownObject()
    {
        movement = character.GetComponent<MovingAbility>();

        if (movement)
            SlowDownObject();
    }

    private void SlowDownObject()
    {
        float originSpeed = movement.Speed;
        movement.Speed *= percentage;
        Action ReturnOrginSpeed= () => movement.Speed = originSpeed;
        MonoBevahiourExtension.StartLerp(movement, 0, time, 0, ReturnOrginSpeed, null);
    }
}
