using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunsMerge
{
    public class ConcentrationShootingButton : MonoBehaviour
    {
        public void Concentration() {
            this.OnEvent(eEventType.ConcetrationShootingRequest);
        }
    }
}
