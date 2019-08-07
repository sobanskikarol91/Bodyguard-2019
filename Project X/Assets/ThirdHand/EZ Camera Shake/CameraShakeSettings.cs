using System;
using UnityEngine;

[Serializable]
public class CameraShakeSettings
{
    public float Magnitude { get => magnitude; }
    public float Roughness { get => roughness; }
    public float FadeInTime { get => fadeInTime; }
    public float FadeOutTime { get => fadeOutTime; }

    [SerializeField] float magnitude;
    [SerializeField] float roughness;
    [SerializeField] float fadeInTime;
    [SerializeField] float fadeOutTime;
}