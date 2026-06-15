using UnityEngine;
using System.Collections;

namespace Generals.Core
{
    /// <summary>
    /// Слушатель глобальных команд и ивентов от администрации.
    /// </summary>
    public class LiveOpsListener : MonoBehaviour
    {
        public void OnReceiveBroadcast(string message)
        {
            Debug.Log($"[LiveOps] Получено глобальное сообщение: {message}");
            Generals.UI.NotificationManager.Instance?.SendNotification(message, true);
        }

        public void OnEventStarted(string eventType, float multiplier)
        {
            Debug.Log($"[LiveOps] Запущен ивент {eventType} с множителем {multiplier}");
            if (eventType == "Double XP")
            {
                // Применение множителя к получению опыта
            }
        }
    }
}
