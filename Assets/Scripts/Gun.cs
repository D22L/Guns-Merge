using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunsMerge
{
    public class Gun : MonoBehaviour
    {
        [field: SerializeField] public GunSettings settings { get; private set; }
        [SerializeField] private Transform _bulletPoint;


        public void Shoot(Vector3 dir)
        {
            var bullet = Instantiate(settings.BulletPfb);
            bullet.transform.position = _bulletPoint.position;
            bullet.SetDamage(settings.Damage);
            bullet.Fly(dir, settings.BulletSpeed);
        }
    }
}
