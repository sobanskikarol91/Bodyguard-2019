using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyAIInput : IMovementInput
{
    public Vector2 Movement { get { return new Vector2(1, 1); }}
}