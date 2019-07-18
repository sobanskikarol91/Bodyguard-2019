using UnityEngine;

[CreateAssetMenu(fileName = "MobileInput", menuName = "Input/Mobile/Settings")]
public class MobileInput : InputManager
{
    [SerializeField] Joystick movement;
    [SerializeField] Joystick rotation;


    public override TwoAxisInput Movement { get { return movement; } protected set { Movement = value; } }
    public override TwoAxisInput Rotation { get { return rotation; } protected set { Rotation = value; } }

    public override InputHandler Fire { get => throw new System.NotImplementedException(); protected set => throw new System.NotImplementedException(); }

    private Joystick currentJoystick;
    private Touch touch;


    public override void Execute()
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

    public override void Init()
    {
        movement.Init();
        //rightJoystick.Init();
    }

    private bool IsTapOnWrongSide()
    {
        return IsRightSideScreen() && currentJoystick == movement || !IsRightSideScreen() && currentJoystick == rotation;
    }

    private void JoystickTouchDetected()
    {
        if (IsTouchEnd())
            OnTouchEnd();
        else
            OnTouching();
    }

    private bool IsTouchEnd()
    {
        return touch.phase == TouchPhase.Ended;
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
        currentJoystick = IsRightSideScreen() ? rotation : movement;
    }

    private bool IsRightSideScreen()
    {
        return touch.position.x > Screen.width / 2;
    }
}