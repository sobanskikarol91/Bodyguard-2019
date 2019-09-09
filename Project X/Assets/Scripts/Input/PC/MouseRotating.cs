using UnityEngine;

[CreateAssetMenu(fileName = "Mouse", menuName = "Input/PC/Mouse")]
public class MouseRotating : TwoAxisInput
{
    private Camera camera;
    private Transform player;


    public override void Execute()
    {
        if (!player) GetPlayerReference();

        Direction = camera.ScreenToWorldPoint(Input.mousePosition) - player.position;
        base.OnInputUsing();
    }

    private void GetPlayerReference()
    {
        player = GameManager.instance.Player.transform;
        camera = Camera.main;
    }
}