using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] protected ObjectType[] damageObjects;
    [SerializeField] protected GameObject effect;
    [SerializeField] protected float damage;

    protected bool IsHitTargetOnDamageObjectsCollection(InteractiveObject target)
    {
        Debug.Log("check collection");
        return damageObjects.Contains(target.Type);
    }
}
