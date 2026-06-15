using UnityEngine;
using System.Collections;

namespace Generals.Core.Cloud
{
    /// <summary>
    /// Управление Пуш-уведомлениями через Firebase Cloud Messaging (FCM).
    /// </summary>
    public class PushNotificationManager : MonoBehaviour
    {
        public void InitializeFCM()
        {
            Debug.Log("[Push] Инициализация Firebase Cloud Messaging...");
            // Подписка на токен
        }

        public void SubscribeToTopic(string topic)
        {
            Debug.Log($"[Push] Подписка на канал: {topic}");
        }

        public void HandleNotificationReceived(string title, string body)
        {
            Debug.Log($"[Push] Получено уведомление: {title} - {body}");
            // Показ локального нотификатора если игра запущена
        }
    }
}
