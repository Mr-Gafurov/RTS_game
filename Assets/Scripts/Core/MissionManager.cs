using UnityEngine;
using System;

namespace Generals.Core
{
    /// <summary>
    /// Менеджер текущей миссии.
    /// </summary>
    public class MissionManager : MonoBehaviour
    {
        public static MissionManager Instance { get; private set; }

        public MissionData currentMission;
        public bool isMissionComplete = false;

        public event Action OnMissionSuccess;
        public event Action OnMissionFail;

        private void Awake()
        {
            Instance = this;
        }

        public void StartMission(MissionData data)
        {
            currentMission = data;
            isMissionComplete = false;
            Debug.Log($"[MissionManager] Начало миссии: {data.missionName}");
        }

        public void CheckObjectives()
        {
            if (isMissionComplete) return;

            // Логика проверки выполнения условий (например, уничтожение всех вражеских зданий)
            // if (enemyBuildings.Count == 0) MissionSuccess();
        }

        private void MissionSuccess()
        {
            isMissionComplete = true;
            OnMissionSuccess?.Invoke();
            Debug.Log("[MissionManager] Миссия выполнена успешно!");

            // Сохранение прогресса
            if (!string.IsNullOrEmpty(currentMission.unlockUnitKey))
            {
                // Логика разблокировки
            }
        }
    }
}
