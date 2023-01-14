using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunsMerge
{
    public abstract class BaseEnemyBehavior : MonoBehaviour, IBehavior
    {
        [SerializeField] protected string animName;

        private bool _animIsPlayed;
        protected Animator animator { get; private set; }
        public float Priority { get; protected set; }
        public abstract void Behave();        
        public abstract void Evaluate();
        public void SetAnimator(Animator animatorValue)
        {
            animator = animatorValue;
        }

        protected void PlayAnim()
        {
            if (_animIsPlayed) return;
            animator.CrossFade(animName, 0.01f);
            _animIsPlayed = true;
        }
    }
}
