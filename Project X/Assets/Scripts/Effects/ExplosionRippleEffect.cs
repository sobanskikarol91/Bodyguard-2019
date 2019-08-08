using UnityEngine;

public class ExplosionRippleEffect : MonoBehaviour 
{
    private void OnEnable()
    {
        RipplePostProcessor.instance.ShowEffect();
    }
}