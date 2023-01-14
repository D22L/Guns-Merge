using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunsMerge
{
    public class ShootAbility : MonoBehaviour
    {
        [SerializeField] private GunController _gunController;
        [SerializeField] private EnemyDetector _enemyDetector;
        [SerializeField] private HeroAnimController _heroAnimController;
        private EnemyBase _currentTarget;
        private float _delay;
        private void OnEnable()
        {
            
        }

        private void Aim()
        {
            var sortedEnemy = _enemyDetector.VisibleEnemies.OrderByDescending(x=>Vector3.Distance(transform.position, x.transform.position));
            _currentTarget = sortedEnemy.Last();
            transform.LookAt(_currentTarget.transform);
        }
        private void Shoot()
        {
            _gunController.CurrentGun.Shoot(transform.forward);
            _heroAnimController.Shoot();
        }

        private void Update()
        {
            if (_enemyDetector.VisibleEnemies.Count > 0) Aim();

            if (_currentTarget == null) return;

           
            _delay += Time.deltaTime;
            if (_delay >= _gunController.CurrentGun.settings.ShootDelay)
            {                
                Shoot();
                _delay = 0;
            }

        }
    }
}
