using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunsMerge
{
    public class AIBehaviorManager : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private List<BaseEnemyBehavior> _behaviors;
        
        private List<IBehavior> _behaviorsList = new List<IBehavior>();
        private IBehavior _currentBehavior;
        private void Awake()
        {
            foreach (var behavior in _behaviors)
            {
                if (behavior is IBehavior b)
                {
                    behavior.SetAnimator(_animator);
                    _behaviorsList.Add(b);
                }
            }
        }
        private void Update()
        {            
            foreach (var behavior in _behaviorsList) behavior.Evaluate();

            float maxPriority = 0f;

            for (int i = 0; i < _behaviorsList.Count; i++)
            {
                if (maxPriority <= _behaviorsList[i].Priority)
                {
                    _currentBehavior = _behaviorsList[i];
                    maxPriority = _behaviorsList[i].Priority;
                }
            }

            _currentBehavior?.Behave();
        }
    }
}
