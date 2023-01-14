using System.Collections;
using UnityEngine;
using DG.Tweening;
using Zenject;

namespace GunsMerge
{
    public class AIDieBehavior : BaseEnemyBehavior
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private Collider _collider;
        [Inject] private Wallet _wallet;
        private EnemyBase _enemyBase;
        private bool _used;
        private void Awake()
        {
            _enemyBase = GetComponent<EnemyBase>();
        }
        public override void Behave()
        {
            if (_used) return;
            _wallet.AddCoin(_enemyBase.EnemySettings.RewardSize);
            _collider.enabled = false;
            PlayAnim();
            StartCoroutine(HideBody());
            _used = true;
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
