using UnityEngine;

namespace Generals.Core
{
    /// <summary>
    /// Менеджер погодных эффектов и времени суток.
    /// </summary>
    public class EnvironmentManager : MonoBehaviour
    {
        public Light globalLight;
        public float dayNightCycleSpeed = 0.1f;

        [Header("Погода")]
        public bool isSandstorm = false;
        public float sandstormVisibilityReduction = 0.5f;

        private void Update()
        {
            // Цикл дня и ночи (вращение солнца)
            if (globalLight != null)
            {
                globalLight.transform.Rotate(Vector3.right * dayNightCycleSpeed * Time.deltaTime);
            }
        }

        public void SetSandstorm(bool active)
        {
            isSandstorm = active;
            Debug.Log($"[Environment] Песчаная буря: {active}");
            // Влияние на FogOfWarManager
        }
    }
}
