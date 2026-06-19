using UnityEngine;
using System.Collections.Generic;

namespace Generals.Core
{
    /// <summary>
    /// Система тумана войны.
    /// </summary>
    public class FogOfWar : MonoBehaviour
    {
        public static FogOfWar Instance { get; private set; }

        public LayerMask unitLayer;
        public float updateInterval = 0.5f;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            // Инициализация текстуры тумана (в реальном проекте это будет Compute Shader или RenderTexture)
            Debug.Log("[FogOfWar] Система инициализирована.");
        }

        public bool IsVisible(Vector3 position)
        {
            // Временно возвращаем true, пока нет реализации рендеринга
            if (ElectronicWarfareManager.Instance != null && ElectronicWarfareManager.Instance.isRadarJammed)
            {
                return false;
            }
            return true;
        }
    }
}
