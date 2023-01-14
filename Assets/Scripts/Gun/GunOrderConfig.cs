using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunsMerge
{
    [CreateAssetMenu(fileName = "GunOrderConfig", menuName = "Configs/GunOrderConfig")]
    public class GunOrderConfig : ScriptableObject
    {
        [field:SerializeField] public List<GunSettings> gunSettings { get; private set; } = new List<GunSettings>();
    }

}
