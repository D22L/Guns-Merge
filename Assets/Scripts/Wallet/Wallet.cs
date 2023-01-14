using System;

namespace GunsMerge
{
    public class Wallet
    {
        public int Coin { get; private set; }

        public event Action onWalletUpdated;
        public void AddCoin(int value)
        {
            Coin += value;
            onWalletUpdated?.Invoke();
        }
        public void TakeCoin(int value) 
        {
            if (value <= Coin)
            {
                Coin -= value;
                onWalletUpdated?.Invoke();
            }
        }
    }
}
