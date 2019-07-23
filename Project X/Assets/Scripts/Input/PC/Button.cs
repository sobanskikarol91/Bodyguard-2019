using UnityEngine;


[CreateAssetMenu(fileName = "Button", menuName = "Input/PC/Button")]
public class Button : InputHandler
{
    [SerializeField] KeyCode button;

    public override void Execute()
    {
        if (Input.GetKeyDown(button))
            OnInputStartUsing();
        else if (Input.GetKey(button))
            OnInputUsing();
        else if (Input.GetKeyUp(button))
            OnInputEndUsing();
    }
}