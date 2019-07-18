using UnityEngine;

[CreateAssetMenu(fileName = "Joystick", menuName = "Input/Mobile/Joystick")]
public class Joystick : TwoAxisInput
{
    [SerializeField] VisualJoystick joystickPrefab;

    public int FingerId { get; private set; }

    private Vector2 pressPos, currentFingerPos;
    private const int notUsedValue = -1;
    private VisualJoystick joystick;


    public void Init()
    {
        joystick = Instantiate(joystickPrefab);
        FingerId = notUsedValue;
    }

    private Vector3 GetWorldTouchPos()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.transform.position.z));
    }

    public override void OnTouchStart(Touch touch)
    {
        this.touch = touch;
        FingerId = touch.fingerId;
        pressPos = GetWorldTouchPos();
        joystick.Circle.transform.position = pressPos;
        joystick.Circle.gameObject.SetActive(true);
        OnInputStartUsing();
    }

    public override void OnTouching(Touch touch)
    {
        this.touch = touch;
        currentFingerPos = GetWorldTouchPos();
        UpdateJoystickPosition();
        OnInputUsing();
    }

    public override void OnTouchEnd()
    {
        FingerId = notUsedValue;
        joystick.Circle.gameObject.SetActive(false);
        OnInputEndUsing();
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
}