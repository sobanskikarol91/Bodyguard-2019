using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Joystick : TwoAxisInput
{
    [SerializeField] Transform circle;
    [SerializeField] Transform innerCircle;

    public int FingerId { get; private set; }

    private Vector2 pressPos, currentFingerPos;
    private new Camera camera;
    private Touch touch;
    private const int notUsedValue = -1;


    private void Start()
    {
        FingerId = notUsedValue;
        camera = Camera.main;
    }

    private Vector3 GetWorldTouchPos()
    {
        return camera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, camera.transform.position.z));
    }

    public void OnTouchStart(Touch touch)
    {
        this.touch = touch;
        FingerId = touch.fingerId;
        pressPos = GetWorldTouchPos();
        circle.transform.position = pressPos;
        circle.gameObject.SetActive(true);
        OnInputStartUsing();
    }

    public void OnTouching(Touch touch)
    {
        this.touch = touch;
        currentFingerPos = GetWorldTouchPos();
        UpdateJoystickPosition();
        OnInputUsing();
    }

    public void OnTouchEnd()
    {
        FingerId = notUsedValue;
        circle.gameObject.SetActive(false);
        OnInputEndUsing();
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
