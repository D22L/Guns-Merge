using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunsMerge
{
    public class AIDieBehavior : BaseEnemyBehavior
    {
        [SerializeField] private HealthComponent _healthComponent;
        public override void Behave()
        {
            PlayAnim();
        }

        public override void Evaluate()
        {
            if (_healthComponent.CurrentValue == 0) Priority = 1f;
            else Priority = 0f;
        }
    }
}
