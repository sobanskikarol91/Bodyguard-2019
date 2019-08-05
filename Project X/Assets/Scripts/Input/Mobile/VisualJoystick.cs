using UnityEngine;

public class VisualJoystick : MonoBehaviour 
{
    [SerializeField] Transform circle;
    [SerializeField] Transform knob;

    public Transform Circle { get { return circle; } }
    public Transform Knob { get { return knob; }  }
}