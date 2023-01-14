using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GunsMerge
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyBase[] _enemiesPfb;
        
        [Inject] private EnvironmentSpawner _environmentSpawner;
        [Inject] private DiContainer _diContainer;

        private int _countEnemies = 3;
        private List<EnemyBase> _enemies = new List<EnemyBase>();
        private void Awake()
        {
            SpawnEnemies();
        }
        private void Start()
        {            
            EnemyWave enemyWave = new EnemyWave(_enemies);
            enemyWave.Start();
        }

        private void SpawnEnemies()
        {
            for (int i = 0; i < _countEnemies; i++)
            {
                var r = Random.Range(0,_enemiesPfb.Length);
                var enemy = _diContainer.InstantiatePrefab(_enemiesPfb[r]);
                _enemies.Add(enemy.GetComponent<EnemyBase>());
                var rPos = Random.Range(0, _environmentSpawner.CurrentChunk.EnemiesPoints.Length);
                enemy.transform.position = _environmentSpawner.CurrentChunk.EnemiesPoints[rPos].position;
                enemy.gameObject.SetActive(false);
            }
        }

    }
}
