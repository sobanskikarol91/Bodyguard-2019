using UnityEngine;

[CreateAssetMenu(fileName = "MobileInput", menuName = "Input/Mobile/Settings")]
public class MobileInput : PlayerInput
{
    [SerializeField] Joystick movement;
    [SerializeField] Joystick rotation;

    public override TwoAxisInput Moving { get => movement; protected set => Moving = value; }
    public override TwoAxisInput Rotating { get => rotation; protected set => Rotating = value; }
    public override InputHandler Shooting { get => rotation; protected set => throw new System.NotImplementedException(); }


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