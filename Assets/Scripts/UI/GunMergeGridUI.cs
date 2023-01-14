using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GunsMerge
{
    public class GunMergeGridUI : MonoBehaviour
    {
        [SerializeField] private GunOrderConfig _config;
        
        [SerializeField] private List<MergeCell> mergeCells = new List<MergeCell>();
        [Inject] private MainHero _mainHero;
        private MergeCell _currentCell;

        private void OnEnable()
        {
            this.Subscribe(eEventType.ChangeActiveCell, OnChangeActiveCell);
        }

        private void OnChangeActiveCell(object arg0)
        {
            _currentCell.TryChangeActiveState(false);
            _currentCell = (MergeCell)arg0;
            _currentCell.TryChangeActiveState(true);
        }

        private void OnDisable()
        {
            this.Unsubscribe(eEventType.ChangeActiveCell, OnChangeActiveCell);
        }


        private void Start()
        {
            var id = _mainHero.CurrentGun.settings.ID;
            var sprite = _mainHero.CurrentGun.settings.GunSprite;
            _currentCell = mergeCells[0];
            _currentCell.SetGun(id, sprite);
            _currentCell.TryChangeActiveState(true);

            mergeCells.ForEach(x => x.Init(_config));
        }

        public bool HaveFreeCell()
        {
            var cell =  mergeCells.Find(x=>x.GunID<0);            
            return cell != null;
        }

        public void AddGun(int id)
        {
            var cell = mergeCells.Find(x => x.GunID < 0);
            var settings = _config.gunSettings.Find(x=>x.ID == id);
            cell.SetGun(id, settings.GunSprite);
        }
    }
}
