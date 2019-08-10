using UnityEngine;

public class LightManager : MonoBehaviour 
{
    [SerializeField] Light mainLight;
    private float originAngle;

    private void Awake()
    {
        originAngle = mainLight.spotAngle;    
    }

    public void DecreaseSpotAngle(float destination, float duration)
    {
        this.StartLerp(originAngle, destination, duration, null, (x) => mainLight.spotAngle = x);
    }

    public void ReturnSpotAngleToOrigin(float duration)
    {
        this.StartLerp(mainLight.spotAngle, originAngle, duration, null, (x) => mainLight.spotAngle = x);
    }
}