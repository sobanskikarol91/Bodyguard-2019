using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingInput : MonoBehaviour, IShootingInput
{
    public Quaternion GetShootDirection()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = ((Vector2)transform.rotation.eulerAngles - mousePos).normalized;
        Debug.Log(direction);
        return Quaternion.Euler(direction);
    }
}
