using UnityEngine;

[CreateAssetMenu(fileName = "GunRecoil", menuName = "Effect/GunRecoil")]
public class GunRecoilEffect : ShootingEffect
{
    [SerializeField] float recoilForce;

    private ShootingAbility ability;
    public override void CreateEffect(Transform transform)
    {
        Vector3 offset = transform.right * recoilForce;
        transform.position -= offset;
    }
}