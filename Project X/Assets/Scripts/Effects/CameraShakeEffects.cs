using EZCameraShake;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraShakeEffect", menuName = "Effect/CameraShake")]
public class CameraShakeEffects : ShootingEffect
{
    [SerializeField] CameraShakeSettings settings;

    public override void CreateEffect(Transform transform)
    {
        CameraShaker.Instance.ShakeOnce(settings);
    }
}