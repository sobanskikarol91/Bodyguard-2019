using UnityEngine;


[CreateAssetMenu(fileName = "MobileInput", menuName = "Input/PC/Settings")]
public class PCInput : InputManager
{
    public override TwoAxisInput Movement { get { return movement; } protected set { Movement = value; } }
    public override TwoAxisInput Rotation { get { return rotation; } protected set { Rotation = value; } }
    public override InputHandler Fire { get { return fire; } protected set { Fire = value; } }

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