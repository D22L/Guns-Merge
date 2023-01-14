using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunsMerge
{
    public abstract class EnemyBase : MonoBehaviour
    {
        [SerializeField] protected HealthComponent _healthComponent;
        [SerializeField] protected BaseEnemySettings _enemySettings;

        public HealthComponent Health => _healthComponent;
        public bool isDead => _healthComponent.CurrentValue == 0;
        public BaseEnemySettings EnemySettings => _enemySettings;
        private void Awake()
        {
            _healthComponent.SetMaxHealth(_enemySettings.MaxHealth);
        }

        public void TakeDamage(float damageSize)
        {
            _healthComponent.TakeDamage(damageSize);
        } 

    }
}
