using System;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public static SlowMotion instance;

    private void Awake()
    {
        instance = this;
    }

    public void RunEffect(float factor, float duration, Action OnComplete = null)
    {
        Time.timeScale = factor;
        OnComplete += () => Time.timeScale = 1;
        this.StartLerp(1f, factor, duration * factor, OnComplete);
    }
}