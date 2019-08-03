using UnityEngine;


public static class CameraExtension
{
    public static Bounds GetBounds(this Camera camera)
    {
        float screenAspect = Screen.width / Screen.height;
        float cameraHeight = camera.orthographicSize * 2;

        Bounds bounds = new Bounds(camera.transform.position, new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }
}