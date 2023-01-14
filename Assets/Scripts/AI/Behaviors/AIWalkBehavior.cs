using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using DG.Tweening;

namespace GunsMerge
{
    public class AIWalkBehavior : BaseEnemyBehavior
    {
        [Inject] private MainHero _mainHero;        
        private BaseEnemySettings _settings;

        private void Awake()
        {
            _settings = GetComponent<EnemyBase>().EnemySettings;    
        }

        public override void Behave()
        {
            PlayAnim();
            transform.LookAt(_mainHero.transform);
            transform.position = Vector3.Lerp(transform.position, _mainHero.transform.position, Time.deltaTime * _settings.MoveSpeed);
        }

        public override void Evaluate()
        {
            if (!gameObject.activeSelf)
            {
                Priority = 0f;
                return;
            }

            var dist = Vector3.Distance(transform.position, _mainHero.transform.position);
            if (_mainHero.Health.CurrentValue > 0 && dist > _settings.AttackDistance) Priority = 0.5f;
            else Priority = 0f;
        }
    }
}
