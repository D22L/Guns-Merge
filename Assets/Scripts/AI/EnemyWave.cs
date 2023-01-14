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
        private int _count = 0;
        private int _startCount = 0;
        private CustomTimer _customTimer;
        public List<EnemyBase> PooledEnemies { get; private set; } = new List<EnemyBase>();
        public event Action onEnd;
        public EnemyWave(List<EnemyBase> enemies)
        {
            _enemies = new Queue<EnemyBase>();
            _startCount = enemies.Count;
            _customTimer = new CustomTimer(1f);
            for (int i = 0; i < enemies.Count; i++)
            {
                _enemies.Enqueue(enemies[i]);                
            }

            EventManager.OnEvent(eEventType.EnemyWaveCreated, this);
        }

        public void RecalculateEnemies()
        {
            _count++;
            if (_count == _startCount)
            {
                EventManager.OnEvent(eEventType.EnemyWaveEnded);
                onEnd?.Invoke();
                _customTimer.onEnd -= _customTimer_onEnd;
                for (int i = 0; i < PooledEnemies.Count; i++)
                {
                    PooledEnemies[i].Health.onHealthZero -= RecalculateEnemies;
                }
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
            if (_enemies.Count > 0)
            {
                PoolEnemy();
                _customTimer.Start();
            }
        }

        private void PoolEnemy()
        {            
            var enemy = _enemies.Dequeue();
            enemy.Health.onHealthZero += RecalculateEnemies;
            PooledEnemies.Add(enemy);
            enemy.gameObject.SetActive(true);                        
        }     
    }
}
