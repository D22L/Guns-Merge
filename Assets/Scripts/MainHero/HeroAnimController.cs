using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunsMerge
{
    public class HeroAnimController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _idleAnimName;
        [SerializeField] private string _walkAnimName;
        [SerializeField] private string _shootAnimName;
        [SerializeField] private string _dieAnimName;
        public void Idle() => _animator.CrossFade(_idleAnimName, 0.01f);
        public void Walk() => _animator.CrossFade(_walkAnimName, 0.01f);
        public void Shoot()
        {            
            _animator.Play(_shootAnimName);
            
        }
        public void Die() => _animator.CrossFade(_dieAnimName, 0.01f);
    }
}
