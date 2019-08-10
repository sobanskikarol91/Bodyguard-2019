using System;
using System.Collections;
using UnityEngine;

public static class MonoBevahiourExtension
{
    public static void StartLerp(this MonoBehaviour target, float origin, float destination, float duration, Action OnComplete = null, Action<float> OnExecuting = null)
    {
        target.StartCoroutine(Lerp(origin, destination, duration, OnComplete, OnExecuting));
    }

    static IEnumerator Lerp(float currentValue, float destination, float duration, Action OnComplete = null, Action<float> OnExecuting = null)
    {
        float startTime = Time.time;
        float startValue = currentValue;

        while (true)
        {
            float percantage = (Time.time - startTime) / duration;
            currentValue = Mathf.Lerp(startValue, destination, percantage);

            OnExecuting?.Invoke(currentValue);
            if (percantage >= 1)
                break;

            yield return null;
        }

        OnComplete?.Invoke();
    }
}