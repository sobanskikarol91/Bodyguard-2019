using UnityEngine;

[CreateAssetMenu(fileName = "ShootingCameraZoom", menuName = "Effect/CameraZoom")]
public class ShootingCameraZoomEffect : ShootingEffect
{
    [SerializeField] float depht;
    [SerializeField] float time;

    public override void CreateEffect(Transform transform)
    {
        CameraZoom.instance.Zoom(time, depht);
    }
}