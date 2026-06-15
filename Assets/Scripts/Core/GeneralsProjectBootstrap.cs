using UnityEngine;

namespace Generals.Core
{
    /// <summary>
    /// Глобальный загрузчик всех систем проекта.
    /// Гарантирует правильный порядок инициализации.
    /// </summary>
    public class GeneralsProjectBootstrap : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("--- ИНИЦИАЛИЗАЦИЯ GENERALS: MOBILE COMMAND ---");

            // Инициализация основных менеджеров
            InitializeSystem(GameManager.Instance);
            InitializeSystem(ResourceManager.Instance);
            InitializeSystem(LocalizationManager.Instance);

            Debug.Log("--- ВСЕ СИСТЕМЫ ГОТОВЫ К БОЮ ---");
        }

        private void InitializeSystem(MonoBehaviour system)
        {
            if (system != null)
                Debug.Log($"[Bootstrap] Система {system.GetType().Name} инициализирована.");
        }
    }
}
