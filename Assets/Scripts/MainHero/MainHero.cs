using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunsMerge
{
    public class MainHero : MonoBehaviour
    {
        [field: SerializeField] public HealthComponent Health { get; private set; }
        [SerializeField] private HeroAnimController _animController;
        [SerializeField] private GunController _gunController;

        public Gun CurrentGun => _gunController.CurrentGun;
        private void OnEnable()
        {
            Health.onHealthZero += Health_onHealthZero;            
        }

        private void Health_onHealthZero()
        {
            _animController.Die();
        }

        private void OnDisable()
        {
            Health.onHealthZero -= Health_onHealthZero;
        }
    }
}
