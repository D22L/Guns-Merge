using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunsMerge
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private Collider _collider;
        
        private int _damage;
        public void SetDamage(int damageSize)
        {
            _damage = damageSize;
        }

        public void Fly(Vector3 dir, float power)
        {
            _rb.AddForce(dir * power);
        }

        private void Start()
        {
            Destroy(gameObject, 2f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out EnemyBase enemy))
            {
                _collider.enabled = false;
                enemy.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}
