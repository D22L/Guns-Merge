using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunsMerge
{
    public class ShootAbility : MonoBehaviour, IAbility
    {
        [SerializeField] private GunController _gunController;
        [SerializeField] private EnemyDetector _enemyDetector;
        [SerializeField] private HeroAnimController _heroAnimController;
        private EnemyBase _currentTarget;
        private float _delay;

        private void Start()
        {
            _delay = _gunController.CurrentGun.settings.ShootDelay;
        }
        private void Aim()
        {            
            var sortedEnemy = _enemyDetector.VisibleEnemies.OrderByDescending(x=>Vector3.Distance(transform.position, x.transform.position));
            _currentTarget = sortedEnemy.Last();
            transform.LookAt(_currentTarget.transform);
        }

        private void Update()
        {
            if (_enemyDetector.VisibleEnemies.Count > 0) Aim();

            if (_currentTarget == null || _currentTarget.isDead) return;
           
            _delay += Time.deltaTime;
            if (_delay >= _gunController.CurrentGun.settings.ShootDelay)
            {
                Execute();
                _delay = 0;
            }

        }

        public void Execute()
        {
            _heroAnimController.Shoot();
        }

        public void Shoot()
        {
            _gunController.CurrentGun.Shoot(transform.forward);           
        }
    }
}
