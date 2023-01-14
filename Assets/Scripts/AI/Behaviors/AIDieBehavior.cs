using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace GunsMerge
{
    public class AIDieBehavior : BaseEnemyBehavior
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private Collider _collider;
        public override void Behave()
        {
            _collider.enabled = false;
            PlayAnim();
            StartCoroutine(HideBody());
        }

        private IEnumerator HideBody()
        {
            yield return new WaitForSeconds(2f);
            transform.DOMoveY(transform.position.y - 0.1f, 3f).OnComplete(() => Destroy(gameObject));

        }
        public override void Evaluate()
        {
            if (_healthComponent.CurrentValue == 0) Priority = 1f;
            else Priority = 0f;
        }
    }
}
