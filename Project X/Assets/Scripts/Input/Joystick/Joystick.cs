using UnityEngine;


public class Joystick : TwoAxisInput
{
    [SerializeField] Transform circle;
    [SerializeField] Transform innerCircle;

    public int FingerId { get; private set; }

    private Vector2 pressPos, currentFingerPos;
    private const int notUsedValue = -1;


    private void Awake()
    {
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
        circle.transform.position = pressPos;
        circle.gameObject.SetActive(true);
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