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

    public void Zoom(float time, float depth)
    {
        this.time = time / 2;
        this.depth = depth;
        StopAllCoroutines();
        StartCoroutine(IEZoom());
    }

    IEnumerator IEZoom()
    {
        float destination = camera.orthographicSize + depth;
        yield return StartCoroutine(StartZoom(destination));

        destination = camera.orthographicSize - depth;
        yield return StartCoroutine(StartZoom(destination));
    }

    IEnumerator StartZoom(float destination)
    {
        float startTime = Time.time;
        float startPosition = camera.orthographicSize;
        Debug.Log("StartPos" + startPosition);

        while (true)
        {
            float percantage = (Time.time - startTime) / time;
            camera.orthographicSize = Mathf.Lerp(startPosition, destination, percantage);

            Debug.Log(camera.orthographicSize);
            if (percantage >= 1)
                break;

            yield return null;
        }
    }
}