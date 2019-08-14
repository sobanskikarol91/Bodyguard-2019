using UnityEngine;

[CreateAssetMenu(fileName = "GunRecoil", menuName = "Effect/GunRecoil")]
public class GunRecoilEffect : ShootingEffect
{
    [SerializeField] float recoilForce;

    private ShootingAbility ability;

    public override void CreateEffect(Transform transform)
    {
        //Vector2 origin = transform.localPosition;
        //ShootingAbility ability = transform.GetComponent<ShootingAbility>();
        //Vector2 destination = transform.right * recoilForce;
        //float duration = ability.Weapon.Settings.RefireRate/2;
    }    
}