using UnityEngine;

namespace Generals.Core
{
    /// <summary>
    /// Динамическое управление производительностью на мобильных устройствах.
    /// </summary>
    public class MobilePerformanceManager : MonoBehaviour
    {
        public float targetFPS = 60f;
        private float _currentFPS;
        private float _deltaTime;

        private void Update()
        {
            _deltaTime += (Time.unscaledDeltaTime - _deltaTime) * 0.1f;
            _currentFPS = 1.0f / _deltaTime;

            if (_currentFPS < targetFPS * 0.8f)
            {
                LowerGraphics();
            }
        }

        private void LowerGraphics()
        {
            // Пример: снижение качества теней или отключение постобработки
            QualitySettings.SetQualityLevel(QualitySettings.GetQualityLevel() - 1, true);
            Debug.Log("[Performance] Снижение качества графики для поддержания FPS.");
        }
    }
}
