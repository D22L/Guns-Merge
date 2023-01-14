using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GunsMerge
{
    public class EnemyDetector : MonoBehaviour
    {        
        public List<EnemyBase> VisibleEnemies { get; private set; } = new List<EnemyBase>();
        
        private EnemyWave _enemyWave;
        private Camera _camera;
        private void Awake()
        {
            _camera = Camera.main;
        }
        private void OnEnable()
        {
            this.Subscribe(eEventType.EnemyWaveCreated, OnEnemyWaveCreated);
        }

        private void OnDisable()
        {
            this.Subscribe(eEventType.EnemyWaveCreated, OnEnemyWaveCreated);
        }

        private void OnEnemyWaveCreated(object arg0)
        {
            _enemyWave = (EnemyWave)arg0;
        }
        private void Update()
        {
            for (int i = 0; i < _enemyWave.PooledEnemies.Count; i++)
            {
                var enemy = _enemyWave.PooledEnemies[i];
                if (!VisibleEnemies.Contains(enemy) && IsTargetVisible(_camera, enemy.gameObject))
                {
                    VisibleEnemies.Add(enemy);
                }
            }    
        }

        bool IsTargetVisible(Camera c, GameObject go)
        {
            var planes = GeometryUtility.CalculateFrustumPlanes(c);
            var point = go.transform.position;
            foreach (var plane in planes)
            {
                if (plane.GetDistanceToPoint(point) < 0)
                    return false;
            }
            return true;
        }
    }
}
