using UnityEngine;
using Cinemachine;
using Zenject;

namespace GunsMerge {
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _vc;

        [Inject] private MainHero _mainHero;

        private void Start()
        {
            _vc.Follow = _mainHero.transform;
            _vc.LookAt = _mainHero.transform;
        }
    }
}