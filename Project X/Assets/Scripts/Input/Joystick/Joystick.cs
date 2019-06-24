using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Joystick : MonoBehaviour, IDirectionInput
{
    [SerializeField] Transform circle;
    [SerializeField] Transform innerCircle;

    public event Action OnUse = delegate { };
    public Vector2 Direction { get; private set; }

    private Vector2 pressPos, currentFingerPos;
    private new Camera camera;

    public int FingerId { get; private set; }
    private Touch touch;

    private const int notUsedValue = -1;
    private void Start()
    {
        FingerId = notUsedValue;
        camera = Camera.main;
    }

    private Vector3 GetWorldMousePos()
    {
        return camera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, camera.transform.position.z));
    }

    public void OnTouchStart(Touch touch)
    {
        Debug.Log("Down" + name);
        this.touch = touch;
        FingerId = touch.fingerId;
        pressPos = GetWorldMousePos();
        circle.transform.position = pressPos;
        circle.gameObject.SetActive(true);
    }

    public void OnTouching(Touch touch)
    {
        this.touch = touch;
        Debug.Log("isTouching" + name);
        currentFingerPos = GetWorldMousePos();
        UpdateJoystickPosition();
        OnUse();
    }

    public void OnTouchEnd()
    {
        Debug.Log("Up" + name);
        FingerId = notUsedValue;
        circle.gameObject.SetActive(false);
    }

    private void UpdateJoystickPosition()
    {
        Direction = Vector2.ClampMagnitude(currentFingerPos - pressPos, 1f);
        innerCircle.transform.position = pressPos + Direction;
    }

    public bool IsNotUsed()
    {
        return FingerId == notUsedValue;
    }
}
