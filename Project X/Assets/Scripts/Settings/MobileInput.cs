using UnityEngine;

[CreateAssetMenu(fileName = "MobileInput", menuName = "Input/Mobile/Settings")]
public class MobileInput : InputManager
{
    [SerializeField] Joystick movement;
    [SerializeField] Joystick rotation;

    public override TwoAxisInput Movement { get { return movement; } protected set { Movement = value; } }
    public override TwoAxisInput Rotation { get { return rotation; } protected set { Rotation = value; } }
    public override InputHandler Fire { get => rotation; protected set => throw new System.NotImplementedException(); }


    public override void Execute()
    {
        movement.Execute();
        rotation.Execute();
    }

    public override void Init()
    {
        movement.Init();
        rotation.Init();
    }
}