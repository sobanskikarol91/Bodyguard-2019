using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class Bullet : MonoBehaviour, IMovement
{
    [SerializeField] protected MoveSettings moveSettings;

    public virtual void Move() { }
}