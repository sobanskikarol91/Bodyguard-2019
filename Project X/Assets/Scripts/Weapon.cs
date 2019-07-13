using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Simple")]
public class Weapon : ScriptableObject
{
    public WeaponSettings Settings { get { return settings; } }
    [SerializeField] WeaponSettings settings;


    [Serializable]
    public class WeaponSettings
    {
        public GameObject Bullet { get { return bullet; } }
        public float RefireRate { get { return refireRate; } }

        [SerializeField] GameObject bullet;
        [SerializeField] float refireRate = 1f;
    }

    public void Shot(Transform transform)
    {
        Transform bullet = ObjectPoolManager.instance.Get(settings.Bullet).transform;
        bullet.rotation = transform.rotation;
        bullet.transform.position = transform.position;
    }
}