using UnityEngine;

namespace Generals.Core
{
    /// <summary>
    /// Точка сбора ресурсов (золото/припасы).
    /// </summary>
    public class ResourceNode : MonoBehaviour
    {
        public float remainingResources = 10000f;
        public float resourcesPerCycle = 100f;

        public float Collect(float amount)
        {
            float collected = Mathf.Min(amount, remainingResources);
            remainingResources -= collected;

            if (remainingResources <= 0)
                Destroy(gameObject);

            return collected;
        }
    }
}
