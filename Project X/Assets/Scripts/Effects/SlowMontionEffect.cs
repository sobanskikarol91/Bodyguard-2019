using UnityEngine;

[CreateAssetMenu(fileName = "SlowMontion", menuName = "Effect/SlowMontion")]
public class SlowMontionEffect : Effect
{
    [SerializeField] float slowdown;
    [SerializeField] float duration;

    public override void CreateEffect(Transform transform)
    {
        SlowMotion.instance.RunEffect(slowdown, duration);
    }
}