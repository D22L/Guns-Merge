using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunsMerge
{
    [CreateAssetMenu(fileName = "GunSettings", menuName = "Configs/GunSettings")]
    public class GunSettings : ScriptableObject
    {
        [field: SerializeField] public int ID { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float ShootDelay { get; private set; }
        [field: SerializeField] public Bullet BulletPfb { get; private set; }
        [field: SerializeField] public float BulletSpeed { get; private set; }
}
}
