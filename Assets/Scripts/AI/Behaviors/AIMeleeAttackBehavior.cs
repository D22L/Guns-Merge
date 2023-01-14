using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GunsMerge
{
    public class AIMeleeAttackBehavior : BaseEnemyBehavior
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
        }

        public void Attack()
        {
            _mainHero.Health.TakeDamage(_settings.AttackPower);
        }

        public override void Evaluate()
        {
            var dist = Vector3.Distance(_mainHero.transform.position, transform.position);

            if (dist < _settings.AttackDistance && _mainHero.Health.CurrentValue > 0) Priority = 0.8f;
            else Priority = 0f;
        }
    }
}
