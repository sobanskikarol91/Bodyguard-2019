using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    private LineRenderer laserBeam;
    private float width;
    private float expireTime;

    void Awake()
    {
        laserBeam = GetComponent<LineRenderer>();
        expireTime = GetComponent<ReturnToPoolAfterTime>().TimeToReturn;
        width = laserBeam.widthCurve.keys[0].value;
    }

    private void UpdateLaserWidth(float width)
    {
        laserBeam.widthCurve = new AnimationCurve(new Keyframe(0, width), new Keyframe(.1f, width));
    }

    private void OnEnable()
    {
        width = 2f;
        MonoBevahiourExtension.StartLerp(this, width, 0, expireTime, null, UpdateLaserWidth);
    }
}
