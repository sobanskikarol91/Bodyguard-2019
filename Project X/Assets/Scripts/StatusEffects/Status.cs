using System;
using UnityEngine;

public abstract class Status
{
    [SerializeField] protected float time;
    public abstract string Name { get; }
    protected Character character;

    public void TryAddStatusToObject(Character character)
    {
        this.character = character;

        if (AreRequirementToAddStatusMet())
            AddStatus();
    }

    private void AddStatus()
    {
        Coroutine corutine = CreateStatus();
        character.Status.AddStatus(Name, corutine);
    }

    public abstract Coroutine CreateStatus();
    protected abstract bool AreRequirementToAddStatusMet();
}
