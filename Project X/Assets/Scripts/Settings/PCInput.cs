using UnityEngine;


[CreateAssetMenu(fileName = "MobileInput", menuName = "Input/PC/Settings")]
public class PCInput : InputManager
{
    public override TwoAxisInput Movement { get { return movement; } protected set { Movement = value; } }
    public override TwoAxisInput Rotation { get { return rotation; } protected set { Rotation = value; } }

    [SerializeField] TwoAxisInput movement;
    [SerializeField] TwoAxisInput rotation;

    public override void Execute()
    {
        movement.OnTouching(new Touch());
        rotation.OnTouching(new Touch());
    }

    public override void Init()
    {

    }
}