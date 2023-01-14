using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GunsMerge
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private Image _healthProgressView;
        [SerializeField] private GameObject _healthbar;
        [SerializeField] private int _maxHealth;
        [SerializeField] private DamageInfoPanel _damageInfo;

        public event Action onHealthZero;
        private float _currentHealth;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void SetMaxHealth(int value)
        {
            _maxHealth = value;
            _currentHealth = _maxHealth;
        }

        public float CurrentValue => _currentHealth;
        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
            _currentHealth = Mathf.Clamp(_currentHealth,0, _maxHealth);
            _healthProgressView.fillAmount = _currentHealth / _maxHealth;
            _damageInfo.ShowDamageInfo(damage);
            if (_currentHealth == 0)
            {
                _healthbar.SetActive(false);
                onHealthZero?.Invoke();                
            }
        }

        public void AddHealth(int healthSize)
        {
            _currentHealth += healthSize;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
            _healthProgressView.fillAmount = _currentHealth / _maxHealth;
        }
    }
}
