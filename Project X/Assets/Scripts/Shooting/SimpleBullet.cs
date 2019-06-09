using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SimpleBullet : Bullet
{
    public override void Move()
    {
        transform.position = transform.forward * moveSettings.Speed;
    }
}