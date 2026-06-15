using UnityEngine;
using System.Collections.Generic;

namespace Generals.Core.Analytics
{
    /// <summary>
    /// Интеграция с Firebase Analytics для отслеживания игровых метрик.
    /// </summary>
    public class FirebaseAnalyticsManager : MonoBehaviour
    {
        public static FirebaseAnalyticsManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public void LogEvent(string eventName, string parameterName, string parameterValue)
        {
            Debug.Log($"[FirebaseAnalytics] Событие: {eventName} | {parameterName}: {parameterValue}");
            // Вызов Firebase.Analytics.FirebaseAnalytics.LogEvent
        }

        public void LogMissionStart(string missionId) => LogEvent("mission_start", "id", missionId);
        public void LogMissionComplete(string missionId) => LogEvent("mission_complete", "id", missionId);
        public void LogPurchase(string itemId, float price) => LogEvent("purchase", "item", itemId);
    }
}
