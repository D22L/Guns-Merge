using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GunsMerge
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyBase[] _enemiesPfb;
        [SerializeField] private int _maxCount = 10;
        [Inject] private EnvironmentSpawner _environmentSpawner;
        [Inject] private DiContainer _diContainer;

        private int _countEnemies = 3;
        private List<EnemyBase> _enemies = new List<EnemyBase>();
        private void Awake()
        {
            _enemies = SpawnEnemies();
        }

        private void OnEnable()
        {
            this.Subscribe(eEventType.HeroInPosition, OnHeroInPosition);
        }

        private void OnDisable()
        {
            this.Unsubscribe(eEventType.HeroInPosition, OnHeroInPosition);
        }

        private void OnHeroInPosition(object arg0)
        {
            _countEnemies++;
            _countEnemies = Mathf.Clamp(_countEnemies, 0, _maxCount);
            _enemies = SpawnEnemies();            
            EnemyWave enemyWave = new EnemyWave(_enemies);
            enemyWave.Start();
        }

        private void Start()
        {            
            EnemyWave enemyWave = new EnemyWave(_enemies);
            enemyWave.Start();
        }

        private List<EnemyBase> SpawnEnemies()
        {
            var enemies = new List<EnemyBase>();
            for (int i = 0; i < _countEnemies; i++)
            {
                var r = Random.Range(0,_enemiesPfb.Length);
                var enemy = _diContainer.InstantiatePrefab(_enemiesPfb[r]);
                enemies.Add(enemy.GetComponent<EnemyBase>());
                var rPos = Random.Range(0, _environmentSpawner.CurrentChunk.EnemiesPoints.Length);
                enemy.transform.position = _environmentSpawner.CurrentChunk.EnemiesPoints[rPos].position;
                enemy.gameObject.SetActive(false);
            }
            return enemies;
        }

    }
}
