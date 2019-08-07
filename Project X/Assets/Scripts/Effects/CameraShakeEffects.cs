using EZCameraShake;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraShakeEffect", menuName = "Effects/CameraShake")]
public class CameraShakeEffects : ShootingEffect
{
    [SerializeField] CameraShakeSettings settings;

    public override void CreateEffect(Transform transform)
    {
        CameraShaker.Instance.ShakeOnce(settings);
    }
}