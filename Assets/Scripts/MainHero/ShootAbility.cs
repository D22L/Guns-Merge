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
        private bool _concentrationState;
        private float _concentrationDuration = 2f;
        private float _concentrationTime;
        private float _maxDelay;
        private void Start()
        {
            _delay = _gunController.CurrentGun.settings.ShootDelay;
        }
        private void OnEnable()
        {
            this.Subscribe(eEventType.ConcetrationShootingRequest, OnConcetrationRequest);
        }

        private void OnDisable()
        {
            this.Unsubscribe(eEventType.ConcetrationShootingRequest, OnConcetrationRequest);
        }
        private void OnConcetrationRequest(object arg0)
        {
            if (_enemyDetector.VisibleEnemies.Count == 0) return;

            _concentrationState = true;
            _heroAnimController.SetSpeed(2f);
        }

        private void Aim()
        {
            var sortedEnemy = _enemyDetector.VisibleEnemies.OrderByDescending(x => Vector3.Distance(transform.position, x.transform.position));
            _currentTarget = sortedEnemy.Last();
            transform.LookAt(_currentTarget.transform);
        }

        private void Update()
        {
            _maxDelay = _gunController.CurrentGun.settings.ShootDelay;
            CheckConcentrationState();

            if (_enemyDetector.VisibleEnemies.Count > 0) Aim();

            if (_currentTarget == null || _currentTarget.isDead) return;

            _delay += Time.deltaTime;
            
                       
            if (_delay >= _maxDelay)
            {
                Debug.Log(_delay);
                Execute();
                _delay = 0;
            }

        }

        private void CheckConcentrationState()
        {
            if (_concentrationState)
            {
                _maxDelay *= 0.5f;
                _concentrationTime += Time.deltaTime;
                if (_concentrationTime >= _concentrationDuration)
                {
                    _concentrationState = false;
                    _concentrationTime = 0f;
                    _heroAnimController.SetSpeed(1f);
                }
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
