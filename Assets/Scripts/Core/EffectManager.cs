using UnityEngine;
using System.Collections.Generic;

namespace Generals.Core
{
    /// <summary>
    /// Менеджер визуальных эффектов (взрывы, выстрелы) с использованием пула объектов.
    /// </summary>
    public class EffectManager : MonoBehaviour
    {
        public static EffectManager Instance { get; private set; }

        [Header("Префабы эффектов")]
        public GameObject explosionPrefab;
        public GameObject muzzleFlashPrefab;

        private void Awake()
        {
            Instance = this;
        }

        public void SpawnExplosion(Vector3 position, float scale = 1.0f)
        {
            GameObject explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
            explosion.transform.localScale = Vector3.one * scale;
            Destroy(explosion, 3f); // В будущем заменить на Pool
        }

        public void SpawnMuzzleFlash(Transform parent)
        {
            GameObject flash = Instantiate(muzzleFlashPrefab, parent.position, parent.rotation, parent);
            Destroy(flash, 0.5f);
        }
    }
}
