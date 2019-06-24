using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Touch touch;
    private delegate bool TouchState();
    private TouchState touchStart, touchEnd, isTouching;


    private void Start()
    {
        SetInputDependsOnPlatform();
    }

    private void Update()
    {
        Debug.Log(Input.touchCount);
        for (int i = 0; i < Input.touchCount; i++)
        {
            touch = Input.touches[i];

            if (IsFingerUsedByOtherJoystick())
                UsedByOtherFinger();
            else
                NewFingerDetected();
        }
    }

    private void UsedByOtherFinger()
    {
        throw new NotImplementedException();
    }

    private void NewFingerDetected()
    {
        throw new NotImplementedException();
    }

    private bool IsFingerUsedByOtherJoystick()
    {
        throw new NotImplementedException();
    }

    private void SetInputDependsOnPlatform()
    {
        touchStart = () => Input.touches.Any(t => t.phase == TouchPhase.Began);
        touchEnd = () => Input.touches.Any(t => t.phase == TouchPhase.Ended);
        isTouching = () => touch.phase == TouchPhase.Moved;
    }

    private void NewFingerDetected()
    {
        if (touchStart())
            OnMouseButtonDown();
        else if (isTouching())
            OnMouseButtonPressing();
    }

    private void UsedByOtherFinger()
    {
        if (touchEnd())
            OnMouseButtonUp();
    }
}
