using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyAIInput : IDirectionInput
{
    public Vector2 Direction { get { return new Vector2(1, 1); }}
}