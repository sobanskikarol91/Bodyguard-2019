using System.Collections.Generic;
using UnityEngine;

public class StatusManager
{
    public Dictionary<string, Coroutine> ActiveStatuses = new Dictionary<string, Coroutine>();
    private InteractiveObject interactiveObject;


    public StatusManager(InteractiveObject interactiveObject)
    {
        this.interactiveObject = interactiveObject;
    }

    public void TryToAddStatus(string name, Coroutine corutine)
    {
        if (IsObjectAlreadyHasThisStatus(name))
            AddStatus(name, corutine);
        else
            ResetStatus(name, corutine);
    }

    private void AddStatus(string name, Coroutine corutine)
    {
        ActiveStatuses.Add(name, corutine);
    }

    private void ResetStatus(string name, Coroutine corutine)
    {
        interactiveObject.StopCoroutine(corutine);
        AddStatus(name, corutine);
    }

    bool IsObjectAlreadyHasThisStatus(string name)
    {
        return ActiveStatuses.ContainsKey(name);
    }
}