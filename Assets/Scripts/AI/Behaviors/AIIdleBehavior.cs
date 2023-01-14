using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GunsMerge
{
    public class AIIdleBehavior : BaseEnemyBehavior
    {
        [Inject] private MainHero _mainHero;
        public override  void Behave()
        {
            PlayAnim();
        }

        public override void Evaluate()
        {
            if (_mainHero.Health.CurrentValue == 0) Priority = 1f;
        }
    }
}
