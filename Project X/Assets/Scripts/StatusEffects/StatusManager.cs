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
            ResetStatus(name, corutine);
        else
            AddStatus(name, corutine);
    }

    private void AddStatus(string name, Coroutine corutine)
    {
        Debug.Log("Add Status");
        ActiveStatuses.Add(name, corutine);
    }

    private void ResetStatus(string name, Coroutine corutine)
    {
        Debug.Log("Reset Status");
        Coroutine previousCorutine = ActiveStatuses[name];
        interactiveObject.StopCoroutine(previousCorutine);
        ActiveStatuses[name] = corutine;
    }

    bool IsObjectAlreadyHasThisStatus(string name)
    {
        return ActiveStatuses.ContainsKey(name);
    }

    public void RemoveStatusFromList(string status)
    {
        Debug.Log("Remove status");
        ActiveStatuses.Remove(status);
    }
}