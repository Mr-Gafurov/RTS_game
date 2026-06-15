using UnityEngine;

namespace Generals.Core
{
    /// <summary>
    /// Источник видимости для тумана войны.
    /// </summary>
    public class VisionSource : MonoBehaviour
    {
        public float visionRadius = 20f;
        public float updateInterval = 0.5f;

        private void Start()
        {
            InvokeRepeating("UpdateVision", 0f, updateInterval);
        }

        private void UpdateVision()
        {
            if (FogOfWarManager.Instance != null)
            {
                FogOfWarManager.Instance.RevealArea(transform.position, visionRadius);
            }
        }
    }
}
