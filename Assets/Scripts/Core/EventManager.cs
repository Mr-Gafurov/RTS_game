using UnityEngine;
using System.Collections.Generic;
using System;

namespace Generals.Core
{
    [Serializable]
    public class LiveEvent
    {
        public string id;
        public string title;
        public DateTime endTime;
        public float xpMultiplier = 1.0f;
    }

    /// <summary>
    /// Менеджер Live-Ops событий.
    /// </summary>
    public class EventManager : MonoBehaviour
    {
        public static EventManager Instance { get; private set; }

        public List<LiveEvent> activeEvents = new List<LiveEvent>();

        private void Awake()
        {
            Instance = this;
        }

        public void RefreshEvents()
        {
            // Логика получения событий с сервера
            Debug.Log("[EventManager] Обновление списка событий...");
        }

        public float GetCurrentXPMultiplier()
        {
            float maxMult = 1.0f;
            foreach (var ev in activeEvents)
            {
                if (DateTime.Now < ev.endTime)
                    maxMult = Mathf.Max(maxMult, ev.xpMultiplier);
            }
            return maxMult;
        }
    }
}
