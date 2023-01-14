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

        public Action onDie;
        public BaseEnemySettings EnemySettings => _enemySettings;
        private void Awake()
        {
            _healthComponent.SetMaxHealth(_enemySettings.MaxHealth);
        }

        private void OnEnable()
        {
            _healthComponent.onHealthZero += _healthComponent_onHealthZero;
        }

        private void _healthComponent_onHealthZero()
        {
            onDie?.Invoke();
        }

        private void OnDisable()
        {
            _healthComponent.onHealthZero -= _healthComponent_onHealthZero;
        }

        public void TakeDamage(float damageSize)
        {
            _healthComponent.TakeDamage(damageSize);
        } 

    }
}
