using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingInput : MonoBehaviour, IShootingInput
{
    public Quaternion GetShootDirection()
    {
        Vector2 start = transform.position;
        Vector2 end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(end.y - start.y, end.x - start.x);
        Debug.Log(angle);
        return Quaternion.Euler(new Vector3(0,0,angle));
    }
}
