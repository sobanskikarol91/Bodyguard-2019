using UnityEngine;

public class InputRotation : Rotation
{
    protected override Vector2 Direction { get => (Vector3)input.Direction; }

    protected override void OnEnable()
    {
        input = GameManager.instance.Input.Rotation;
        base.OnEnable();
    }
}
