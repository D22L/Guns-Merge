using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunsMerge
{    
    public abstract class BaseEnemySettings : ScriptableObject
    {
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float AttackDistance { get; private set; }
        [field: SerializeField] public float AttackPower { get; private set; }
        [field: SerializeField] public int MaxHealth { get; private set; }
        [field: SerializeField] public int RewardSize { get; private set; }
    }
}
