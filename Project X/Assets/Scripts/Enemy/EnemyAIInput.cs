using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyAIInput : IInput
{
    public Vector2 Movement { get { return new Vector2(1, 1); }}
}