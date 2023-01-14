using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace GunsMerge
{
    public class DamageInfoPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textPfb;
        [SerializeField] private int _startCount;
        private List<TextMeshProUGUI> _textFields = new List<TextMeshProUGUI>();
        private void Awake()
        {
            InstantiateFields();
        }

        private void InstantiateFields()
        {
            for (int i = 0; i < _startCount; i++)
            {
                var field = Instantiate(_textPfb,transform);
                field.gameObject.SetActive(false);
                _textFields.Add(field);
            }
        }

        public void ShowDamageInfo(float damage)
        {
            var field = _textFields.First(x=>!x.gameObject.activeSelf);
            if (field == null)
            {
                field = Instantiate(_textPfb, transform);
                _textFields.Add(field);
            }
            field.gameObject.SetActive(true);
            field.text = damage.ToString();
            field.transform.DOMoveY(transform.position.y +  0.2f, 1f).OnComplete(()=>field.gameObject.SetActive(false));
            
        } 
    }
}
