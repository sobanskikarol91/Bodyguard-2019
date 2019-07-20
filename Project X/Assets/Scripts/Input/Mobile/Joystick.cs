using System;
using UnityEngine;

enum JoystickPosition { Left, Right }

[CreateAssetMenu(fileName = "Joystick", menuName = "Input/Mobile/Joystick")]
public class Joystick : TwoAxisInput
{
    public int FingerId { get; private set; }

    [SerializeField] VisualJoystick joystickPrefab;
    [SerializeField] JoystickPosition position;

    private Vector2 pressPos, currentFingerPos;
    private const int notUsedValue = -1;
    private VisualJoystick joystick;
    private Touch touch;
    private Camera camera;


    public void Init()
    {
        camera = Camera.main;
        joystick = Instantiate(joystickPrefab);
        FingerId = notUsedValue;
    }

    public override void Execute()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            touch = Input.touches[i];

            if (IsTappedOnRightSideScreen())
                JoystickUsed();
        }
    }

    private Vector3 GetWorldTouchPos()
    {
        return camera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.transform.position.z));
    }
      
    protected override void OnInputStartUsing()
    {
        FingerId = touch.fingerId;
        pressPos = GetWorldTouchPos();
        joystick.Circle.transform.position = pressPos;
        joystick.Circle.gameObject.SetActive(true);

        base.OnInputStartUsing();
    }

    protected override void OnInputUsing()
    {
        currentFingerPos = GetWorldTouchPos();
        UpdateJoystickPosition();

        base.OnInputUsing();
    }

    protected override void OnInputEndUsing()
    {
        FingerId = notUsedValue;
        joystick.Circle.gameObject.SetActive(false);

        base.OnInputEndUsing();
    }

    private void UpdateJoystickPosition()
    {
        Direction = Vector2.ClampMagnitude(currentFingerPos - pressPos, 1f);
        joystick.InnerCircle.position = pressPos + Direction;
    }

    public bool IsNotUsed()
    {
        return FingerId == notUsedValue;
    }

    private void JoystickUsed()
    {
        if (IsTheSameFingerAsJoystickFinger())
            JoystickTouchDetected();
        else if (IsNotUsed())
            OnInputStartUsing();
    }

    private void JoystickTouchDetected()
    {
        if (IsTouchEnd())
            OnInputEndUsing();
        else
            OnInputUsing();
    }

    private bool IsTouchEnd()
    {
        return touch.phase == TouchPhase.Ended;
    }

    private bool IsTheSameFingerAsJoystickFinger()
    {
        return touch.fingerId == FingerId;
    }

    private bool IsTappedOnRightSideScreen()
    {
        return position == JoystickPosition.Right ? touch.position.x > Screen.width / 2 : touch.position.x <= Screen.width / 2;
    }
}