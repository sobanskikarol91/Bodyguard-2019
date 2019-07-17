using UnityEngine;

[CreateAssetMenu(fileName = "MobileInput", menuName = "Input/Mobile")]
public class MobileInput : InputManager
{
    [SerializeField] TwoAxisInput moveJoystick;
    [SerializeField] TwoAxisInput rotateJoystick;

    public override TwoAxisInput Movement { get; protected set; }
    public override TwoAxisInput Rotation { get; protected set; }


    private void Awake()
    {
        Movement = Instantiate(moveJoystick).GetComponent<TwoAxisInput>();
        Rotation = Instantiate(rotateJoystick.gameObject).GetComponent<TwoAxisInput>();
    }
}