using System;
using System.Collections;
using UnityEngine;

public static class MonoBevahiourExtension
{
    public static void StartLerp(this MonoBehaviour target, float origin, float destination, float duration, Action OnComplete = null)
    {
        target.StartCoroutine(IELerp(origin, destination, duration, OnComplete));
    }

    static IEnumerator IELerp(float origin, float destination, float duration, Action OnComplete = null)
    {
        float startTime = Time.time;

        while (true)
        {
            float percantage = (Time.time - startTime) / duration;
            origin = Mathf.Lerp(origin, destination, percantage);

            if (percantage >= 1)
                break;

            yield return null;
        }

        OnComplete?.Invoke();
    }
}