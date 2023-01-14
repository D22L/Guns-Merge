using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

namespace GunsMerge
{
    [RequireComponent(typeof(Button))]
    public class BuyGunButton : MonoBehaviour
    {
        [SerializeField] private GunMergeGridUI _mergeGrid;
        [SerializeField] private GunOrderConfig _gunsConfig;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private Image _gunImage;
        [SerializeField] private Button _button;

        [Inject] private Wallet _wallet;
        private int _price;
        private void Awake()
        {
            _button.onClick.AddListener(OnClick);
            _price = _gunsConfig.gunSettings[0].Price;
            _gunImage.sprite = _gunsConfig.gunSettings[0].GunSprite;
            _priceText.text = _price.ToString();
        }

        private void OnClick()
        {
            if (_price > _wallet.Coin || !_mergeGrid.HaveFreeCell()) return;

            _wallet.TakeCoin(_price);
            _mergeGrid.AddGun(_gunsConfig.gunSettings[0].ID);

        }
    }
}
