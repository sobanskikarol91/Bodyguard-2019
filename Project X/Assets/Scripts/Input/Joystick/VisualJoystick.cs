using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class VisualJoystick : MonoBehaviour 
{
    [SerializeField] Transform circle;
    [SerializeField] Transform innerCircle;

    public Transform Circle { get { return circle; } }
    public Transform InnerCircle { get { return innerCircle; }  }
}