using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GunsMerge
{
    public class EnvironmentSpawner : MonoBehaviour
    {
        [SerializeField] private EnvChunk _envPFB;
        [SerializeField] private int _countInStart =  3;
        [SerializeField] private float _padding = 1f;
        
        private List<EnvChunk> _chunks = new List<EnvChunk>();
        private int _indexCurrentChunk = 0;
        public EnvChunk CurrentChunk => _chunks[_indexCurrentChunk];
        private void Awake()
        {
            SpawnChunks();
        }

        private void SpawnChunks()
        {
            Vector3 currentLocalPos = Vector3.zero;
            for (int i = 0; i < _countInStart; i++)
            {
                var chunk =  Instantiate(_envPFB, transform);
                chunk.transform.localPosition = currentLocalPos;
                currentLocalPos.z += _padding;
                _chunks.Add(chunk);
            }
        }
    }
}
