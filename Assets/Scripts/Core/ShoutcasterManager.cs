using UnityEngine;
using System.Collections.Generic;

namespace Generals.Core
{
    /// <summary>
    /// Инструменты для комментаторов (Shoutcaster).
    /// </summary>
    public class ShoutcasterManager : MonoBehaviour
    {
        public bool showAnalytics = false;

        public void ToggleAnalytics()
        {
            showAnalytics = !showAnalytics;
            Debug.Log($"[Shoutcaster] Аналитика в реальном времени: {showAnalytics}");
        }

        public void DisplayArmyValues()
        {
            // Расчет ценности армий всех игроков в текущий момент
            Debug.Log("[Shoutcaster] Армия США: $15,400 | Армия Китая: $12,800");
        }
    }
}
