using UnityEngine;
using System.Collections.Generic;
using System;

namespace Generals.UI
{
    /// <summary>
    /// Менеджер уведомлений в реальном времени.
    /// </summary>
    public class NotificationManager : MonoBehaviour
    {
        public static NotificationManager Instance { get; private set; }

        public event Action<string> OnNotificationReceived;

        private void Awake()
        {
            Instance = this;
        }

        public void SendNotification(string message, bool isCritical = false)
        {
            Debug.Log($"[Notification] {(isCritical ? "КРИТИЧЕСКОЕ: " : "")}{message}");
            OnNotificationReceived?.Invoke(message);

            // Если критическое - можно проиграть особый звук ("Base under attack")
            if (isCritical)
            {
                // AudioManager.Instance.PlaySFX(...)
            }
        }
    }
}
