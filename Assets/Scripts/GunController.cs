using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunsMerge
{
    public class GunController : MonoBehaviour
    {
        [SerializeField] private List<Gun> _guns = new List<Gun>();

        public Gun CurrentGun { get; private set; }

        private void Awake()
        {
            CurrentGun = _guns[0];
            CurrentGun.gameObject.SetActive(true);
        }

        private void OnEnable()
        {
            this.Subscribe(eEventType.NewGunMerged, OnNewGunMerged);
        }

        private void OnDisable()
        {
            this.Unsubscribe(eEventType.NewGunMerged, OnNewGunMerged);
        }

        private void OnNewGunMerged(object arg0)
        {
            int id = (int)arg0;
            CurrentGun = _guns.Find(x=>x.settings.ID == id);
            CurrentGun?.gameObject.SetActive(true);
        }
    }
}
