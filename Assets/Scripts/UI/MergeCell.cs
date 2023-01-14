using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace GunsMerge
{
    public class MergeCell : MonoBehaviour, IDragHandler, IEndDragHandler, IDropHandler
    {
        [SerializeField] private Image _gunImage;
        [SerializeField] private GameObject _selectedBack;
        private GunOrderConfig _config;
        public int GunID { get; private set; } =-1;
        public Sprite GunSprite { get; private set; }        
        private MergeCell _cellTarget;

        public void Init(GunOrderConfig config)
        {
            _config = config;
        }
        public void SetTargetCell(MergeCell cell)
        {            
            _cellTarget = cell;
            Debug.Log(_cellTarget.name);
        }

        public void ResetImagePos()
        {
            _gunImage.transform.localPosition = Vector3.zero;
        }
       
        public void SetGun(int id, Sprite sprite)
        {
            _gunImage.sprite = sprite;
            GunID = id;
            GunSprite = sprite;
            _gunImage.gameObject.SetActive(true);
        }

        public void RemoveGun()
        {
            GunID = -1;
            _gunImage.gameObject.SetActive(false);           
        }

        public void TryChangeActiveState(bool state)
        {                                    
            _selectedBack.gameObject.SetActive(state);
        }

        public void OnDrag(PointerEventData eventData)
        {            
            _gunImage.transform.position = Input.mousePosition;
            this.OnEvent(eEventType.ChangeActiveCell, this);
        } 

        public void OnEndDrag(PointerEventData eventData)
        {            
            _gunImage.transform.localPosition = Vector3.zero;            
        }

        public void OnDrop(PointerEventData eventData)
        {
            var dragObj = eventData.pointerDrag;
            if (dragObj.TryGetComponent(out MergeCell cell))
            {
                if (cell.GunID < 0) return;
                if (GunID < 0)
                {
                    SetGun(cell.GunID, cell.GunSprite);
                    this.OnEvent(eEventType.ChangeActiveCell, this);
                    cell.RemoveGun();
                }
                else if (GunID == cell.GunID) 
                {
                    var settings = _config.gunSettings.Find(x=>x.ID == GunID+1);
                    if (settings != null)
                    {
                        SetGun(settings.ID, settings.GunSprite);
                        cell.RemoveGun();
                        this.OnEvent(eEventType.ChangeActiveCell, this);
                        this.OnEvent(eEventType.GunMerged, settings.ID);
                    }

                }                
            }            
        }
    }
}
