using System;
using System.Collections;
using UnityEngine;

public static class MonoBevahiourExtension
{
    public static void StartLerp(this MonoBehaviour target, float origin, float destination, float duration, Action OnComplete = null, Action<float> OnExecuting = null)
    {
        target.StartCoroutine(IELerp(origin, destination, duration, OnComplete, OnExecuting));
    }

    static IEnumerator IELerp(float origin, float destination, float duration, Action OnComplete = null, Action<float> OnExecuting = null)
    {
        float startTime = Time.time;

        while (true)
        {
            float percantage = (Time.time - startTime) / duration;
            origin = Mathf.Lerp(origin, destination, percantage);

            OnExecuting?.Invoke(origin);
            Debug.Log(origin + " " + percantage);
            if (percantage >= 1)
                break;

            yield return null;
        }

        OnComplete?.Invoke();
        Debug.Log("Lerp Complete" );
    }
}