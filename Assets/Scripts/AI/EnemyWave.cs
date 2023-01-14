using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace GunsMerge
{
    public class EnemyWave
    {
        private Queue<EnemyBase> _enemies = new Queue<EnemyBase>();
        private float _delay = 0.5f;
        private int _count = 0;
        private int _startCount = 0;
        private CustomTimer _customTimer;
        public List<EnemyBase> PooledEnemies { get; private set; } = new List<EnemyBase>();
        public event Action onEnd;
        public EnemyWave(List<EnemyBase> enemies)
        {
            _startCount = enemies.Count;
            _customTimer = new CustomTimer(1f);
            for (int i = 0; i < enemies.Count; i++)
            {
                _enemies.Enqueue(enemies[i]);
                enemies[i].onDie = RemoveEnemy;
            }

            EventManager.OnEvent(eEventType.EnemyWaveCreated, this);
        }

        public void RemoveEnemy()
        {
            _count++;
            if (_count == _startCount)
            {
                onEnd?.Invoke();
                _customTimer.onEnd -= _customTimer_onEnd;
            }
        }

        public void Start()
        {
            PoolEnemy();
            _customTimer.Start();
            _customTimer.onEnd += _customTimer_onEnd;
        }

        private void _customTimer_onEnd()
        {
            PoolEnemy();
            _customTimer.Start();
        }

        private void PoolEnemy()
        {            
            var enemy = _enemies.Dequeue();
            PooledEnemies.Add(enemy);
            enemy.gameObject.SetActive(true);                        
        }
    }
}
