using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rotation : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;

    protected void Update()
    {
        Vector2 direction = Direction();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }

    protected abstract Vector2 Direction();
}
