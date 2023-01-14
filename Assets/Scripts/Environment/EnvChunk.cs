using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunsMerge
{
    public class EnvChunk : MonoBehaviour
    {
        [field: SerializeField] public Transform CharacterPoint { get; private set; }
        [field: SerializeField] public Transform[] EnemiesPoints { get; private set; }
    }
}
