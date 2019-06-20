using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SimpleBullet : Bullet
{
    public override void Move()
    {
        transform.Translate(transform.right * speed * Time.smoothDeltaTime);
    }
}