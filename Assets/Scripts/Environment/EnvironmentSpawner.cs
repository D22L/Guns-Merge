using System;
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

        private void OnEnable()
        {
            this.Subscribe(eEventType.HeroInPosition, OnHeroInPosistion);
        }


        private void OnHeroInPosistion(object arg0)
        {            
            var lastChunk = _chunks[_chunks.Count - 1];
            _chunks[_indexCurrentChunk-1].transform.position = lastChunk.transform.position + Vector3.forward * _padding;
        }

        private void OnDisable()
        {
            this.Unsubscribe(eEventType.HeroInPosition, OnHeroInPosistion);
        }
        public EnvChunk GetNextChunk()
        {            
            _indexCurrentChunk = (++_indexCurrentChunk) % _chunks.Count;
            return _chunks[_indexCurrentChunk];
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
