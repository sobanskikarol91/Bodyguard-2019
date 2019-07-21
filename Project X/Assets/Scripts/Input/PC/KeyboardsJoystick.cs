using UnityEngine;

[CreateAssetMenu(fileName = "JoystickKeyboard", menuName = "Input/PC/JoystickKeyboard")]
public class KeyboardsJoystick: TwoAxisInput
{
    [SerializeField] string horizontalAxis = "Horizontal";
    [SerializeField] string verticalAxis = "Vertical";


    public override void Execute()
    {
        float verticalMove = Input.GetAxis(verticalAxis);
        float horizontalMove = Input.GetAxis(horizontalAxis);

        Direction = new Vector2(horizontalMove, verticalMove);

        base.OnInputUsing();
    }
}