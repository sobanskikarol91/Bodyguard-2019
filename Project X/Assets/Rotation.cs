using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rotation : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;

    protected abstract Vector2 Direction { get; }

    protected void Rotate()
    {
        float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, transform.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
