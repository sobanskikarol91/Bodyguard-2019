using UnityEngine;

enum JoystickPosition { Left, Right }

[CreateAssetMenu(fileName = "Joystick", menuName = "Input/Mobile/Joystick")]
public class Joystick : TwoAxisInput
{
    public int FingerId { get; private set; }

    [SerializeField] VisualJoystick joystickPrefab;
    [SerializeField] JoystickPosition position;
    [SerializeField] private float maxKnobOffset = 1f;

    private Vector2 tapStartPos;
    private const int notUsedValue = -1;
    private VisualJoystick visualJoystick;
    private Touch touch;
    private Camera camera;


    public void Init()
    {
        camera = Camera.main;
        visualJoystick = Instantiate(joystickPrefab);
        visualJoystick.Hide();
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
      
    protected override void OnInputStartUsing()
    {
        tapStartPos = touch.position;
        FingerId = touch.fingerId;
        base.OnInputStartUsing();
    }

    private void UpdateJoystickPosition()
    {
        visualJoystick.Circle.transform.position = (Vector2)camera.ScreenToWorldPoint(tapStartPos);
        visualJoystick.Circle.gameObject.SetActive(true);
    }

    private Vector2 GetTouchWorldPosition()
    {
        return camera.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
    }

    protected override void OnInputUsing()
    {
        UpdateJoystickPosition();
        UpdateKnob();

        base.OnInputUsing();
    }

    protected override void OnInputEndUsing()
    {
        FingerId = notUsedValue;
        visualJoystick.Hide();
        Direction = Vector2.zero;

        base.OnInputEndUsing();
    }

    private void UpdateKnob()
    {
        Vector2 worldTouch = camera.ScreenToWorldPoint(touch.position);
        Vector2 worldTouchStart = camera.ScreenToWorldPoint(tapStartPos);

        Vector2 knobOffsetFromCenter = worldTouch - worldTouchStart;

        Direction = Vector2.ClampMagnitude(knobOffsetFromCenter, maxKnobOffset);
        visualJoystick.Knob.localPosition =  Direction;
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