using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager
{
    public Dictionary<string, Coroutine> ActiveStatuses = new Dictionary<string, Coroutine>();

    public void AddStatus(string name, Coroutine corutine)
    {
        if (IsObjectAlreadyHasThisStatus(name))
            ActiveStatuses.Add(name, corutine);
        else
            ResetStatus(name);
    }

    private void ResetStatus(string name)
    {
        throw new NotImplementedException();
    }

    bool IsObjectAlreadyHasThisStatus(string name)
    {
        return ActiveStatuses.ContainsKey(name);
    }
}
