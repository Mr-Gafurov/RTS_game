using UnityEngine;
using System;

namespace Generals.Core
{
    /// <summary>
    /// Глобальная система событий для уведомления UI и других систем.
    /// </summary>
    public static class EventManager
    {
        public static event Action<string> OnNotification;
        public static event Action<string, int> OnTechUnlocked;
        public static event Action<EWLevel> OnEWActivated;

        public static void TriggerNotification(string message)
        {
            OnNotification?.Invoke(message);
        }

        public static void TriggerTechUnlocked(string techId, int level)
        {
            OnTechUnlocked?.Invoke(techId, level);
        }

        public static void TriggerEWActivated(EWLevel level)
        {
            OnEWActivated?.Invoke(level);
        }
    }
}
