using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : InteractiveObject
{
    public StatusManager Status { get; protected set; } = new StatusManager
}