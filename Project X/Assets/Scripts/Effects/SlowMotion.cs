using System;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public static SlowMotion instance;

    private void Awake()
    {
        instance = this;
    }

    public void RunEffect(float factor, float duration)
    {
        Time.timeScale = factor;
        Action Oncomplete = () => Time.timeScale = 1;
        this.StartLerp(1f, factor, duration * factor, Oncomplete);
    }
}