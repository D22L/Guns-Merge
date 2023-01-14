using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using DG.Tweening;
using TMPro;
namespace GunsMerge
{
    public class MoneyCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textField;
        [Inject] private Wallet _wallet;

        private int _currentValue;
        private void Awake()
        {
            _currentValue = _wallet.Coin;
            _textField.text = _currentValue.ToString();
        }

        private void OnEnable()
        {
            _wallet.onWalletUpdated += _wallet_onWalletUpdated;
        }

        private void _wallet_onWalletUpdated()
        {
            DOTween.To(()=>_currentValue, (x)=> _currentValue = x, _wallet.Coin, 1f)
                .OnUpdate(()=>_textField.text = _currentValue.ToString());
        }

        private void OnDisable()
        {
            _wallet.onWalletUpdated -= _wallet_onWalletUpdated;
        }
    }
}
