using UnityEngine;
using System;

namespace Generals.Core
{
    /// <summary>
    /// Заглушка для интеграции с PlayFab.
    /// </summary>
    public class CloudAccountManager : MonoBehaviour
    {
        public string playFabId;
        public bool isLoggedIn = false;

        public void Login(string username, string password)
        {
            Debug.Log($"[Cloud] Попытка входа для пользователя: {username}");
            // Вызов PlayFab API
            isLoggedIn = true;
        }

        public void SavePlayerStats(int elo, int wins)
        {
            if (!isLoggedIn) return;
            Debug.Log($"[Cloud] Сохранение статистики: ELO={elo}, Wins={wins}");
        }

        public void SyncInventory()
        {
            Debug.Log("[Cloud] Синхронизация инвентаря и скинов...");
        }
    }
}
