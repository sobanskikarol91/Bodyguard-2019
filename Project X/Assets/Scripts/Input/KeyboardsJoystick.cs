using UnityEngine;


public class KeyboardsJoystick: TwoAxisInput
{
    [SerializeField] string horizontalAxis = "Horizontal";
    [SerializeField] string verticalAxis = "Vertical";


    public override void OnTouching(Touch touch)
    {
        float verticalMove = Input.GetAxis(verticalAxis);
        float horizontalMove = Input.GetAxis(horizontalAxis);

        Direction = new Vector2(horizontalMove, verticalMove);

        OnInputUsing();
    }

    public override void OnTouchEnd()
    {

    }

    public override void OnTouchStart(Touch touch)
    {
        
    }
}