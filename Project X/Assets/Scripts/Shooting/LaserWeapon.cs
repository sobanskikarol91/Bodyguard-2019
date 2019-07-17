using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Laser")]
public class LaserWeapon : Weapon
{
    [SerializeField] float beamLength;
    [SerializeField] ObjectType interact;


    public override void Shoot(Transform shotPoint)
    {
        LineRenderer line = ObjectPoolManager.instance.Get(Bullet).GetComponent<LineRenderer>();
                
        line.positionCount = 2;
        line.SetPosition(0, shotPoint.position);
        line.SetPosition(1, shotPoint.position + shotPoint.right * beamLength);
        DamageOnRaycastHit  damageOnRaycastHit =  line.GetComponent<DamageOnRaycastHit>();
        damageOnRaycastHit.CastRay(shotPoint.position, shotPoint.right, beamLength, interact); 
    }
}