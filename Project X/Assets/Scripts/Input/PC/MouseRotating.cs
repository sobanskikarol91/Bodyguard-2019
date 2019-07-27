using UnityEngine;

[CreateAssetMenu(fileName = "Mouse", menuName = "Input/PC/Mouse")]
public class MouseRotating : TwoAxisInput
{
    private Camera camera;

    private void OnEnable()
    {
        camera = Camera.main;  
    }

    public override void Execute()
    {
        Direction = camera.ScreenToWorldPoint(Input.mousePosition);
        base.OnInputUsing();
    }
}