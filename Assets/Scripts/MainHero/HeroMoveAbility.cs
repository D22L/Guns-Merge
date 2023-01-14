using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using DG.Tweening;

namespace GunsMerge
{
    public class HeroMoveAbility : MonoBehaviour, IAbility
    {
        [Inject] private EnvironmentSpawner _environmentSpawner;
        [SerializeField] private HeroAnimController _animController;
        [SerializeField] private float _moveDuration = 3f;
        private void OnEnable()
        {
            this.Subscribe(eEventType.EnemyWaveEnded, OnEnemyWaveEnded);    
        }

        private void OnDisable()
        {
            this.Unsubscribe(eEventType.EnemyWaveEnded, OnEnemyWaveEnded);
        }

        private void OnEnemyWaveEnded(object arg0)
        {
            _animController.Walk();
            var chunk =  _environmentSpawner.GetNextChunk();
            transform.DOMove(chunk.CharacterPoint.position, _moveDuration)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
            {
                _animController.Idle();
                this.OnEvent(eEventType.HeroInPosition);                
            });
        }

        public void Execute()
        {
            
        }
    }
}
