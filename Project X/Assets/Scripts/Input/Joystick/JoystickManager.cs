using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class JoystickManager : MonoBehaviour
{
    [SerializeField] Joystick leftJoystick;
    [SerializeField] Joystick rightJoystick;

    private delegate bool TouchState();
    private TouchState touchEnd;
    private Joystick currentJoystick;
    private Touch touch;


    private void Start()
    {
        SetInputDependsOnPlatform();
    }

    private void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            touch = Input.touches[i];

            ChooseTapJoystickSide();

            if (IsTapOnWrongSide())
                continue;
            else if (IsTheSameFingerAsJoystickFinger())
                JoystickTouchDetected();
            else if (currentJoystick.IsNotUsed())
                OnTouchStart();
        }
    }

    private void SetInputDependsOnPlatform()
    {
        touchEnd = () => touch.phase == TouchPhase.Ended;
    }

    private bool IsTapOnWrongSide()
    {
        return IsRightSideScreen() && currentJoystick == leftJoystick || !IsRightSideScreen() && currentJoystick == rightJoystick;
    }

    private void JoystickTouchDetected()
    {
        if (touchEnd())
            OnTouchEnd();
        else
            OnTouching();
    }

    private bool IsTheSameFingerAsJoystickFinger()
    {
        return touch.fingerId == currentJoystick.FingerId;
    }

    private void OnTouchEnd()
    {
        currentJoystick.OnTouchEnd();
    }

    private void OnTouching()
    {
        currentJoystick.OnTouching(touch);
    }

    private void OnTouchStart()
    {
        currentJoystick.OnTouchStart(touch);
    }

    private void ChooseTapJoystickSide()
    {
        currentJoystick = IsRightSideScreen() ? rightJoystick : leftJoystick;
    }

    private bool IsRightSideScreen()
    {
        return touch.position.x > Screen.width / 2;
    }
}