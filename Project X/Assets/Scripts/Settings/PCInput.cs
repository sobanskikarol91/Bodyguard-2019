using UnityEngine;


[CreateAssetMenu(fileName = "MobileInput", menuName = "Input/PC/Settings")]
public class PCInput : PlayerInput
{
    public override TwoAxisInput Moving { get { return movement; } protected set { Moving = value; } }
    public override TwoAxisInput Rotating { get { return rotation; } protected set { Rotating = value; } }
    public override InputHandler Shooting { get { return fire; } protected set { Shooting = value; } }

    [SerializeField] TwoAxisInput movement;
    [SerializeField] TwoAxisInput rotation;
    [SerializeField] InputHandler fire;


    public override void Execute()
    {
        movement.Execute();
        rotation.Execute();
        fire.Execute();
    }

    public override void Init()
    {
    
    }
}