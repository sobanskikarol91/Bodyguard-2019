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
        StartCoroutine(IEZoomInAndOut());
    }

    public void ZoomOutAndIn(float time, float depth)
    {
        this.time = time / 2;
        this.depth = depth;
        StartCoroutine(IEZoomOutAndIn());
    }

    public void ZoomIn(float time, float depth)
    {
        this.time = time;
        this.depth = depth;
        StartCoroutine(IEZoomIn());
    }

    public void ZoomOut(float time, float depth)
    {
        this.time = time;
        this.depth = depth;
        StartCoroutine(IEZoomOut());
    }

    IEnumerator IEZoomInAndOut()
    {
        yield return StartCoroutine(IEZoomIn());
        yield return StartCoroutine(IEZoomOut());
    }

    IEnumerator IEZoomOutAndIn()
    {
        yield return StartCoroutine(IEZoomOut());
        yield return StartCoroutine(IEZoomIn());
    }

    IEnumerator IEZoomIn()
    {
        float destination = camera.orthographicSize - depth;
        yield return StartCoroutine(StartZoom(destination));
    }

    IEnumerator IEZoomOut()
    {
        float destination = camera.orthographicSize + depth;
        yield return StartCoroutine(StartZoom(destination));
    }

    IEnumerator StartZoom(float destination)
    {
        this.StartLerp(camera.orthographicSize, destination, time, null, (x) => camera.orthographicSize = x);
        yield return new WaitForSeconds(time);
    }
}