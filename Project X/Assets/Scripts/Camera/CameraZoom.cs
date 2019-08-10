using System.Collections;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private new Camera camera;
    private float time, depth;
    public static CameraZoom instance;

    private void Awake()
    {
        instance = this;
        camera = Camera.main;
    }

    public void ZoomInAndOut(float time, float depth)
    {
        this.time = time / 2;
        this.depth = depth;
        StopAllCoroutines();
        StartCoroutine(IEZoomInAndOut());
    }

    public void ZoomOutAndIn(float time, float depth)
    {
        this.time = time / 2;
        this.depth = depth;
        StopAllCoroutines();
        StartCoroutine(IEZoomOutAndIn());
    }

    IEnumerator IEZoomInAndOut()
    {
        float destination = camera.orthographicSize + depth;
        yield return StartCoroutine(StartZoom(destination));

        destination = camera.orthographicSize - depth;
        yield return StartCoroutine(StartZoom(destination));
    }

    IEnumerator IEZoomOutAndIn()
    {
        float destination = camera.orthographicSize - depth;
        yield return StartCoroutine(StartZoom(destination));

        destination = camera.orthographicSize + depth;
        yield return StartCoroutine(StartZoom(destination));
    }

    IEnumerator StartZoom(float destination)
    {
        float startTime = Time.time;
        float startPosition = camera.orthographicSize;

        while (true)
        {
            float percantage = (Time.time - startTime) / time;
            camera.orthographicSize = Mathf.Lerp(startPosition, destination, percantage);

            if (percantage >= 1)
                break;

            yield return null;
        }
    }
}