using UnityEngine;
using System.Collections.Generic;

namespace Generals.Core
{
    /// <summary>
    /// Оптимизированный пул для частиц.
    /// </summary>
    public class ParticlePool : MonoBehaviour
    {
        public static ParticlePool Instance { get; private set; }

        public GameObject particlePrefab;
        public int poolSize = 20;

        private Queue<GameObject> _pool = new Queue<GameObject>();

        private void Awake()
        {
            Instance = this;
            InitializePool();
        }

        private void InitializePool()
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(particlePrefab, transform);
                obj.SetActive(false);
                _pool.Enqueue(obj);
            }
        }

        public GameObject Get()
        {
            if (_pool.Count > 0)
            {
                GameObject obj = _pool.Dequeue();
                obj.SetActive(true);
                return obj;
            }
            return Instantiate(particlePrefab); // Расширение при необходимости
        }

        public void ReturnToPool(GameObject obj)
        {
            obj.SetActive(false);
            _pool.Enqueue(obj);
        }
    }
}
