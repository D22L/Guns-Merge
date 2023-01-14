using DG.Tweening;
using System;

namespace GunsMerge
{
    public class CustomTimer
    {
        private Tween tween;
        private float _duration;
        private float _currentValue;

        public event Action onEnd;
        public CustomTimer(float duration)
        {
            _duration = duration;
        }

        public void Start()
        {
            tween = DOTween.To(()=> _currentValue, (x) => _currentValue =x, _duration,_duration).OnComplete(()=>onEnd?.Invoke());
        }
        public void Stop() { tween.Kill(); }
    }
}
