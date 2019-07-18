using UnityEngine;

[CreateAssetMenu(fileName = "MobileInput", menuName = "Input/Mobile")]
public class MobileInput : InputManager
{
    [SerializeField] Joystick leftJoystickPrefab;
    [SerializeField] Joystick rightJoystickPrefab;

    public override TwoAxisInput Movement { get { return leftJoystick; } protected set { Movement = value; } }
    public override TwoAxisInput Rotation { get { return rightJoystick; } protected set { Rotation = value; } }

    private Joystick leftJoystick;
    private Joystick rightJoystick;
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
        leftJoystick =  Instantiate(leftJoystickPrefab);
        rightJoystick = Instantiate(rightJoystickPrefab);
    }

    private bool IsTapOnWrongSide()
    {
        return IsRightSideScreen() && currentJoystick == leftJoystick || !IsRightSideScreen() && currentJoystick == rightJoystick;
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
        currentJoystick = IsRightSideScreen() ? rightJoystick : leftJoystick;
    }

    private bool IsRightSideScreen()
    {
        return touch.position.x > Screen.width / 2;
    }
}