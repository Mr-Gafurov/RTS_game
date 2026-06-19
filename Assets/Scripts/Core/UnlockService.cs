using UnityEngine;
using System;
using System.Collections.Generic;

namespace Generals.Core
{
    /// <summary>
    /// Сервис управления разблокировками контента (юниты, карты, режимы).
    /// Связывает достижения и прогресс миссий с доступными технологиями.
    /// </summary>
    public class UnlockService : MonoBehaviour
    {
        public static UnlockService Instance { get; private set; }

        public event Action<string> OnContentUnlocked;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        /// <summary>
        /// Проверяет условия разблокировки после завершения миссии.
        /// </summary>
        public void ProcessMissionCompletion(MissionData mission, bool isHardDifficulty)
        {
            // Пример: Если миссия пройдена на высоком уровне сложности, открываем авианосцы.
            if (isHardDifficulty && mission.title.Contains("Desert Storm"))
            {
                UnlockContent("SEA_UNITS_CARRIER");
            }

            // Награда за любую победу в этой миссии
            if (!string.IsNullOrEmpty(mission.unlockTechId))
            {
                UnlockContent(mission.unlockTechId);
            }
        }

        public void UnlockContent(string contentKey)
        {
            if (TechManager.Instance != null && !TechManager.Instance.IsTechUnlocked(contentKey))
            {
                TechManager.Instance.UnlockTech(contentKey);
                OnContentUnlocked?.Invoke(contentKey);
                Debug.Log($"[UnlockService] Контент разблокирован: {contentKey}");

                // Уведомляем игрока
                Generals.UI.NotificationManager.Instance?.SendNotification($"НОВЫЙ КОНТЕНТ: {contentKey}", true);
            }
        }
    }
}
